import { useMemo, useState, useEffect, useCallback } from 'react';
import { Empty, Typography, Button, Popconfirm, Tag, Dropdown, Tooltip } from 'antd';
import {
  DeleteOutlined,
  LockOutlined,
  DatabaseOutlined,
  MoreOutlined,
  AppstoreAddOutlined,
  FormOutlined,
  CaretDownOutlined,
  CaretRightOutlined,
  PlusOutlined,
  TableOutlined,
  FileTextOutlined,
} from '@ant-design/icons';
import { useEditorStore } from '../store/editorStore';
import type { Group } from '../hooks/useSchema';

const { Text } = Typography;

interface SchemaTreeProps {
  groups: Group[];
  tierColor: string;
  onAddSubGroup: (parentGroupId: number) => void;
  onAddAttribute: (groupId: number) => void;
  onDeleteGroup: (groupId: number) => void;
  onDeleteAttribute: (attributeId: number) => void;
  searchTerm?: string;
}

/** Count direct child groups */
function countChildGroups(group: Group): number {
  return group.subGroups?.length ?? 0;
}

export function SchemaTree({
  groups,
  tierColor,
  onAddSubGroup,
  onAddAttribute,
  onDeleteGroup,
  onDeleteAttribute,
  searchTerm,
}: SchemaTreeProps) {
  const { selectedNodeId, setSelectedNode } = useEditorStore();
  const [expandedCategories, setExpandedCategories] = useState<Set<number>>(new Set());
  const [expandedGroups, setExpandedGroups] = useState<Set<number>>(new Set());

  // Auto-expand all on mount
  useEffect(() => {
    const catIds = new Set<number>();
    const grpIds = new Set<number>();
    for (const g of groups) {
      catIds.add(g.id);
      if (g.subGroups) {
        for (const sg of g.subGroups) {
          grpIds.add(sg.id);
        }
      }
    }
    setExpandedCategories(catIds);
    setExpandedGroups(grpIds);
  }, [groups]);

  // Expand all when searching
  useEffect(() => {
    if (searchTerm) {
      const catIds = new Set<number>();
      const grpIds = new Set<number>();
      for (const g of groups) {
        catIds.add(g.id);
        if (g.subGroups) {
          for (const sg of g.subGroups) {
            grpIds.add(sg.id);
          }
        }
      }
      setExpandedCategories(catIds);
      setExpandedGroups(grpIds);
    }
  }, [searchTerm, groups]);

  const toggleCategory = useCallback((id: number) => {
    setExpandedCategories(prev => {
      const next = new Set(prev);
      if (next.has(id)) next.delete(id);
      else next.add(id);
      return next;
    });
  }, []);

  const toggleGroup = useCallback((id: number) => {
    setExpandedGroups(prev => {
      const next = new Set(prev);
      if (next.has(id)) next.delete(id);
      else next.add(id);
      return next;
    });
  }, []);

  // Filter groups by search term
  const filteredGroups = useMemo(() => {
    if (!searchTerm) return groups;
    const term = searchTerm.toLowerCase();
    return groups
      .map(category => {
        const matchedSubs = (category.subGroups ?? []).filter(sg =>
          sg.name.toLowerCase().includes(term) ||
          (sg.attributes && sg.attributes.some(a => a.name.toLowerCase().includes(term)))
        );
        if (
          category.name.toLowerCase().includes(term) ||
          matchedSubs.length > 0
        ) {
          return { ...category, subGroups: matchedSubs.length > 0 ? matchedSubs : category.subGroups };
        }
        return null;
      })
      .filter(Boolean) as Group[];
  }, [groups, searchTerm]);

  if (groups.length === 0) {
    return (
      <div style={{ padding: 40, textAlign: 'center' }}>
        <Empty
          image={<DatabaseOutlined style={{ fontSize: 48, color: 'rgba(0,0,0,0.1)' }} />}
          description={<Text type="secondary" style={{ fontSize: 12 }}>Tầng này chưa có dữ liệu</Text>}
        />
      </div>
    );
  }

  const isCategory = (g: Group) => !g.sqlTableName;

  return (
    <div className="schema-tree-v2">
      {filteredGroups.map(category => {
        if (!isCategory(category)) {
          // Direct table group (no parent category) — render as standalone
          return (
            <TableGroupNode
              key={category.id}
              group={category}
              tierColor={tierColor}
              expanded={expandedGroups.has(category.id)}
              onToggle={() => toggleGroup(category.id)}
              selectedNodeId={selectedNodeId}
              setSelectedNode={setSelectedNode}
              onAddAttribute={onAddAttribute}
              onAddSubGroup={onAddSubGroup}
              onDeleteGroup={onDeleteGroup}
              onDeleteAttribute={onDeleteAttribute}
            />
          );
        }

        const isCatExpanded = expandedCategories.has(category.id);
        const childCount = countChildGroups(category);

        return (
          <div key={category.id} className="schema-category" style={{ marginBottom: 4 }}>
            {/* Category Header */}
            <div
              className="schema-category-header"
              style={{
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'space-between',
                padding: '8px 12px',
                cursor: 'pointer',
                borderRadius: 8,
                transition: 'background 0.15s',
                userSelect: 'none',
              }}
              onClick={() => toggleCategory(category.id)}
            >
              <div style={{ display: 'flex', alignItems: 'center', gap: 8, flex: 1, minWidth: 0 }}>
                {isCatExpanded
                  ? <CaretDownOutlined style={{ color: tierColor, fontSize: 11 }} />
                  : <CaretRightOutlined style={{ color: tierColor, fontSize: 11 }} />
                }
                <Text strong style={{ fontSize: 13, color: '#333' }}>{category.name}</Text>
                <Text type="secondary" style={{ fontSize: 11 }}>{childCount}</Text>
              </div>
              <Tooltip title="Thêm nhóm con">
                <Button
                  type="text"
                  size="small"
                  icon={<PlusOutlined style={{ fontSize: 11 }} />}
                  onClick={(e) => { e.stopPropagation(); onAddSubGroup(category.id); }}
                  style={{ padding: '0 4px', height: 22, color: tierColor, opacity: 0.7 }}
                />
              </Tooltip>
            </div>

            {/* Category Children */}
            {isCatExpanded && (
              <div style={{ paddingLeft: 12 }}>
                {(category.subGroups ?? []).map(sg => (
                  <TableGroupNode
                    key={sg.id}
                    group={sg}
                    tierColor={tierColor}
                    expanded={expandedGroups.has(sg.id)}
                    onToggle={() => toggleGroup(sg.id)}
                    selectedNodeId={selectedNodeId}
                    setSelectedNode={setSelectedNode}
                    onAddAttribute={onAddAttribute}
                    onAddSubGroup={onAddSubGroup}
                    onDeleteGroup={onDeleteGroup}
                    onDeleteAttribute={onDeleteAttribute}
                  />
                ))}
              </div>
            )}
          </div>
        );
      })}
    </div>
  );
}

/** Renders a table-level group with its attributes */
function TableGroupNode({
  group,
  tierColor,
  expanded,
  onToggle,
  selectedNodeId,
  setSelectedNode,
  onAddAttribute,
  onAddSubGroup,
  onDeleteGroup,
  onDeleteAttribute,
}: {
  group: Group;
  tierColor: string;
  expanded: boolean;
  onToggle: () => void;
  selectedNodeId: string | null;
  setSelectedNode: (id: string | null, type: 'group' | 'attribute' | null) => void;
  onAddAttribute: (groupId: number) => void;
  onAddSubGroup: (parentGroupId: number) => void;
  onDeleteGroup: (groupId: number) => void;
  onDeleteAttribute: (attributeId: number) => void;
}) {
  const nodeKey = `g_0_${group.id}`;
  const isSelected = selectedNodeId === nodeKey;
  const attrCount = group.attributes?.length ?? 0;

  const menuItems = [
    { key: 'add-attr', icon: <FormOutlined />, label: 'Thêm thuộc tính' },
    { key: 'add-subgroup', icon: <AppstoreAddOutlined />, label: 'Thêm nhóm con' },
    { type: 'divider' as const },
    {
      key: 'delete',
      icon: <DeleteOutlined />,
      label: group.isCore ? 'Xóa (Core)' : 'Xóa nhóm',
      danger: true,
    },
  ];

  return (
    <div style={{ marginBottom: 2 }}>
      {/* Group Row */}
      <div
        className="schema-group-row"
        style={{
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'space-between',
          padding: '6px 12px',
          borderRadius: 8,
          cursor: 'pointer',
          transition: 'all 0.15s',
          background: isSelected ? `${tierColor}12` : 'transparent',
          borderLeft: isSelected ? `3px solid ${tierColor}` : '3px solid transparent',
        }}
        onClick={() => {
          setSelectedNode(nodeKey, 'group');
          if (attrCount > 0) onToggle();
        }}
      >
        <div style={{ display: 'flex', alignItems: 'center', gap: 8, flex: 1, minWidth: 0 }}>
          {attrCount > 0 ? (
            expanded
              ? <CaretDownOutlined style={{ color: '#999', fontSize: 10 }} />
              : <CaretRightOutlined style={{ color: '#999', fontSize: 10 }} />
          ) : (
            <span style={{ width: 10 }} />
          )}
          <TableOutlined style={{ color: tierColor, fontSize: 13 }} />
          <Text style={{ fontSize: 12.5, fontWeight: 500 }}>{group.name}</Text>
          <Text type="secondary" style={{ fontSize: 10, flexShrink: 0 }}>{attrCount}</Text>
        </div>

        <div className="schema-group-actions" style={{ display: 'flex', alignItems: 'center', gap: 2, opacity: 0, transition: 'opacity 0.15s' }}>
          <Tooltip title="Thêm thuộc tính">
            <Button
              type="text"
              size="small"
              icon={<PlusOutlined style={{ fontSize: 10 }} />}
              onClick={(e) => { e.stopPropagation(); onAddAttribute(group.id); }}
              style={{ padding: '0 4px', height: 20, color: tierColor }}
            />
          </Tooltip>
          <Dropdown
            menu={{
              items: menuItems,
              onClick: ({ key, domEvent }) => {
                domEvent.stopPropagation();
                if (key === 'add-attr') onAddAttribute(group.id);
                else if (key === 'add-subgroup') onAddSubGroup(group.id);
                else if (key === 'delete') {
                  if (group.isCore) {
                    if (confirm('Đây là Core group! Xóa có thể gây lỗi hệ thống. Tiếp tục?')) {
                      onDeleteGroup(group.id);
                    }
                  } else {
                    onDeleteGroup(group.id);
                  }
                }
              },
            }}
            trigger={['click']}
            placement="bottomRight"
          >
            <Button
              type="text"
              size="small"
              icon={<MoreOutlined style={{ fontSize: 12 }} />}
              onClick={(e) => e.stopPropagation()}
              style={{ padding: '0 4px', height: 20, color: '#999' }}
            />
          </Dropdown>
        </div>
      </div>

      {/* Attributes */}
      {expanded && group.attributes && group.attributes.length > 0 && (
        <div style={{ paddingLeft: 36 }}>
          {group.attributes.map(attr => {
            const attrKey = `a_${group.id}_${attr.id}`;
            const isAttrSelected = selectedNodeId === attrKey;

            return (
              <div
                key={attr.id}
                className="schema-attr-row"
                style={{
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'space-between',
                  padding: '4px 10px',
                  borderRadius: 6,
                  cursor: 'pointer',
                  transition: 'all 0.15s',
                  background: isAttrSelected ? 'rgba(79,70,229,0.06)' : 'transparent',
                }}
                onClick={() => setSelectedNode(attrKey, 'attribute')}
              >
                <div style={{ display: 'flex', alignItems: 'center', gap: 6, flex: 1, minWidth: 0 }}>
                  <FileTextOutlined style={{ color: '#94a3b8', fontSize: 11 }} />
                  <Text style={{ fontSize: 11.5 }}>{attr.name}</Text>
                  {attr.isCore && <LockOutlined style={{ color: '#d97706', fontSize: 9 }} />}
                  {attr.dataType && (
                    <Tag
                      color="default"
                      style={{ fontSize: 9, lineHeight: '14px', padding: '0 4px', margin: 0, borderRadius: 3 }}
                    >
                      {attr.dataType}
                    </Tag>
                  )}
                </div>
                <span className="schema-attr-actions" style={{ opacity: 0, transition: 'opacity 0.15s' }}>
                  <Popconfirm
                    title={attr.isCore ? 'Core field! Xóa có thể gây lỗi.' : 'Xác nhận xóa?'}
                    onConfirm={(e) => { e?.stopPropagation(); onDeleteAttribute(attr.id); }}
                    onCancel={(e) => e?.stopPropagation()}
                    okText="Xóa"
                    cancelText="Hủy"
                    okButtonProps={{ danger: true }}
                  >
                    <Button
                      type="text"
                      size="small"
                      icon={<DeleteOutlined style={{ fontSize: 11 }} />}
                      danger
                      onClick={(e) => e.stopPropagation()}
                      style={{ padding: '0 4px', height: 18 }}
                    />
                  </Popconfirm>
                </span>
              </div>
            );
          })}
        </div>
      )}
    </div>
  );
}
