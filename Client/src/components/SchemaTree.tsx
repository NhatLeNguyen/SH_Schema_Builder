import { useMemo, useState, useEffect } from 'react';
import { Tree, Empty, Typography, Space, Button, Popconfirm, Tag, Dropdown } from 'antd';
import {
  FolderOutlined,
  FolderOpenOutlined,
  FileTextOutlined,
  DeleteOutlined,
  LockOutlined,
  DatabaseOutlined,
  MoreOutlined,
  AppstoreAddOutlined,
  FormOutlined,
} from '@ant-design/icons';
import { useEditorStore } from '../store/editorStore';
import type { Group } from '../hooks/useSchema';
import type { DataNode } from 'antd/es/tree';

const { Text } = Typography;

interface SchemaTreeProps {
  groups: Group[];
  onAddSubGroup: (parentGroupId: number) => void;
  onAddAttribute: (groupId: number) => void;
  onDeleteGroup: (groupId: number) => void;
  onDeleteAttribute: (attributeId: number) => void;
  searchTerm?: string;
}

export function SchemaTree({ groups, onAddSubGroup, onAddAttribute, onDeleteGroup, onDeleteAttribute, searchTerm }: SchemaTreeProps) {
  const { selectedNodeId, setSelectedNode } = useEditorStore();
  const [expandedKeys, setExpandedKeys] = useState<React.Key[]>([]);

  // Collect all group keys recursively
  const collectAllKeys = (gs: Group[], parentKey: string = '0'): React.Key[] => {
    const keys: React.Key[] = [];
    gs.forEach(g => {
      keys.push(`g_${parentKey}_${g.id}`);
      if (g.subGroups) keys.push(...collectAllKeys(g.subGroups, String(g.id)));
    });
    return keys;
  };

  // Auto-expand all on mount and group change
  useEffect(() => {
    setExpandedKeys(collectAllKeys(groups));
  }, [groups]);

  // Expand all when searching
  useEffect(() => {
    if (searchTerm) {
      setExpandedKeys(collectAllKeys(groups));
    }
  }, [searchTerm, groups]);

  const filteredGroups = useMemo(() => {
    if (!searchTerm) return groups;
    const term = searchTerm.toLowerCase();
    return groups.filter(g =>
      g.name.toLowerCase().includes(term) ||
      (g.attributes && g.attributes.some(a => a.name.toLowerCase().includes(term))) ||
      (g.subGroups && g.subGroups.some((sg: any) => sg.name.toLowerCase().includes(term)))
    );
  }, [groups, searchTerm]);

  const buildTreeData = (groupList: Group[], parentKey: string = '0', depth: number = 0): DataNode[] => {
    return groupList.map(group => {
      const nodeKey = `g_${parentKey}_${group.id}`;
      const children: DataNode[] = [];
      const hasSubGroups = group.subGroups && group.subGroups.length > 0;
      const attrCount = group.attributes?.length || 0;

      // Sub-groups first
      if (hasSubGroups) {
        children.push(...buildTreeData(group.subGroups!, String(group.id), depth + 1));
      }

      // Then attributes
      if (group.attributes) {
        group.attributes.forEach(attr => {
          children.push({
            key: `a_${group.id}_${attr.id}`,
            title: (
              <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', width: '100%' }}>
                <Space size={4}>
                  <FileTextOutlined style={{ color: '#3b82f6', fontSize: 12 }} />
                  <Text style={{ fontSize: 12.5 }}>{attr.name}</Text>
                  {attr.isCore && <LockOutlined style={{ color: '#d97706', fontSize: 9 }} />}
                  {attr.dataType && (
                    <Tag
                      color="processing"
                      style={{ fontSize: 9, lineHeight: '14px', padding: '0 4px', margin: 0, borderRadius: 4 }}
                    >
                      {attr.dataType}
                    </Tag>
                  )}
                </Space>
                <span className="tree-node-actions" style={{ opacity: 0, transition: 'opacity 0.2s' }}>
                  <Popconfirm
                    title={attr.isCore ? '⚠️ Core field! Xóa có thể gây lỗi hệ thống.' : 'Xác nhận xóa thuộc tính?'}
                    onConfirm={(e) => { e?.stopPropagation(); onDeleteAttribute(attr.id); }}
                    onCancel={(e) => e?.stopPropagation()}
                    okText="Xóa"
                    cancelText="Hủy"
                    okButtonProps={{ danger: true }}
                  >
                    <Button type="text" size="small" icon={<DeleteOutlined />} danger onClick={(e) => e.stopPropagation()} style={{ padding: '0 4px', height: 20 }} />
                  </Popconfirm>
                </span>
              </div>
            ),
            isLeaf: true,
          });
        });
      }

      // Group action menu items
      const menuItems = [
        { key: 'add-subgroup', icon: <AppstoreAddOutlined />, label: 'Thêm nhóm con' },
        { key: 'add-attr', icon: <FormOutlined />, label: 'Thêm thuộc tính' },
        { type: 'divider' as const },
        {
          key: 'delete',
          icon: <DeleteOutlined />,
          label: group.isCore ? 'Xóa (Core — cẩn thận!)' : 'Xóa nhóm',
          danger: true,
        },
      ];

      return {
        key: nodeKey,
        title: (
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', width: '100%' }}>
            <div style={{ display: 'flex', alignItems: 'flex-start', gap: 8, minWidth: 0, flex: 1 }}>
              <span style={{ marginTop: 2, flexShrink: 0 }}>
                {expandedKeys.includes(nodeKey)
                  ? <FolderOpenOutlined style={{ color: depth === 0 ? '#4f46e5' : '#f59e0b', fontSize: 14 }} />
                  : <FolderOutlined style={{ color: depth === 0 ? '#4f46e5' : '#f59e0b', fontSize: 14 }} />
                }
              </span>
              <div style={{ minWidth: 0, flex: 1 }}>
                <div style={{ display: 'flex', alignItems: 'center', gap: 6 }}>
                  <Text strong style={{ fontSize: 13, lineHeight: 1.3 }}>{group.name}</Text>
                  {group.isCore && (
                    <Tag color="volcano" style={{ fontSize: 8, lineHeight: '13px', padding: '0 3px', margin: 0, borderRadius: 3, fontWeight: 800 }}>
                      CORE
                    </Tag>
                  )}
                  {attrCount > 0 && (
                    <Text type="secondary" style={{ fontSize: 9 }}>({attrCount})</Text>
                  )}
                </div>
                <Text type="secondary" style={{ fontSize: 9, fontFamily: 'monospace', display: 'block', lineHeight: 1.4 }}>{group.sqlTableName}</Text>
              </div>
            </div>
            <span className="tree-node-actions" style={{ opacity: 0, transition: 'opacity 0.2s', flexShrink: 0 }}>
              <Dropdown
                menu={{
                  items: menuItems,
                  onClick: ({ key, domEvent }) => {
                    domEvent.stopPropagation();
                    if (key === 'add-subgroup') onAddSubGroup(group.id);
                    else if (key === 'add-attr') onAddAttribute(group.id);
                    else if (key === 'delete') {
                      if (group.isCore) {
                        if (confirm('⚠️ Đây là Core group! Xóa có thể gây lỗi hệ thống. Tiếp tục?')) {
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
                  icon={<MoreOutlined />}
                  onClick={(e) => e.stopPropagation()}
                  style={{ padding: '0 4px', height: 22, color: '#888' }}
                />
              </Dropdown>
            </span>
          </div>
        ),
        children: children.length > 0 ? children : undefined,
      };
    });
  };

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

  const treeData = buildTreeData(filteredGroups);

  return (
    <>
      <style>{`
        .schema-tree .ant-tree-treenode:hover .tree-node-actions { opacity: 1 !important; }
        .schema-tree .ant-tree-treenode { padding: 3px 0 !important; transition: background 0.15s; }
        .schema-tree .ant-tree-node-content-wrapper { border-radius: 8px !important; padding: 6px 8px !important; transition: all 0.2s !important; }
        .schema-tree .ant-tree-node-content-wrapper:hover { background: rgba(79,70,229,0.04) !important; }
        .schema-tree .ant-tree-node-selected .ant-tree-node-content-wrapper { background: rgba(79,70,229,0.08) !important; box-shadow: inset 3px 0 0 #4f46e5; }
        .schema-tree .ant-tree-indent-unit { width: 20px !important; }
        .schema-tree .ant-tree-switcher { width: 20px !important; }
      `}</style>
      <Tree
        className="schema-tree"
        treeData={treeData}
        expandedKeys={expandedKeys}
        onExpand={(keys) => setExpandedKeys(keys)}
        selectedKeys={selectedNodeId ? [selectedNodeId] : []}
        onSelect={(keys) => {
          if (keys.length === 0) return;
          const key = String(keys[0]);
          if (key.startsWith('g_')) {
            setSelectedNode(key, 'group');
          } else if (key.startsWith('a_')) {
            setSelectedNode(key, 'attribute');
          }
        }}
        showLine={false}
        blockNode
        style={{ background: 'transparent' }}
      />
    </>
  );
}
