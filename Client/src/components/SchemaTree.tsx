import { useMemo } from 'react';
import { useEditorStore } from '../store/editorStore';
import type { Group } from '../hooks/useSchema';
import { FolderOutlined, FileTextOutlined, EllipsisOutlined, PlusOutlined, DeleteOutlined, LockOutlined } from '@ant-design/icons';
import { Tree, Dropdown, Tooltip, Empty, Modal } from 'antd';
import type { MenuProps } from 'antd';
import type { DataNode } from 'antd/es/tree';

interface SchemaTreeProps {
  groups: Group[];
  tierId: number;
  onAddSubGroup: (parentGroupId: number) => void;
  onAddAttribute: (groupId: number) => void;
  onDeleteGroup: (groupId: number) => void;
  onDeleteAttribute: (attributeId: number) => void;
}

export function SchemaTree({ groups, onAddSubGroup, onAddAttribute, onDeleteGroup, onDeleteAttribute }: SchemaTreeProps) {
  const { selectedNodeId, setSelectedNode } = useEditorStore();

  const handleSelect = (selectedKeys: React.Key[]) => {
    if (selectedKeys.length > 0) {
      const key = selectedKeys[0].toString();
      const isAttr = key.startsWith('a_');
      setSelectedNode(key, isAttr ? 'attribute' : 'group');
    } else {
      setSelectedNode(null, null);
    }
  };

  const menuCreator = (type: 'group' | 'attribute', id: number, isCore: boolean): MenuProps => {
    const items: MenuProps['items'] = [];
    if (type === 'group') {
      items.push({
        key: 'add-attr',
        label: 'Thêm thuộc tính',
        icon: <PlusOutlined />,
        onClick: (e: any) => { e.domEvent.stopPropagation(); onAddAttribute(id); }
      });
      items.push({
        key: 'add-sub',
        label: 'Thêm thư mục con',
        icon: <FolderOutlined />,
        onClick: (e: any) => { e.domEvent.stopPropagation(); onAddSubGroup(id); }
      });
      items.push({ type: 'divider' });
      items.push({
        key: 'delete-group',
        label: 'Xóa thư mục',
        icon: <DeleteOutlined />,
        danger: true,
        onClick: (e: any) => { 
          e.domEvent.stopPropagation();
          Modal.confirm({
            title: isCore ? 'Cảnh báo: Đây là core field từ schema gốc!' : 'Xác nhận xóa',
            content: `Bạn có chắc chắn muốn xóa thư mục này không?${isCore ? ' Hành động này có thể gây lỗi hệ thống.' : ''}`,
            okText: 'Xóa',
            okType: 'danger',
            cancelText: 'Hủy',
            onOk: () => onDeleteGroup(id)
          });
        }
      });
    } else {
      items.push({
        key: 'delete-attr',
        label: 'Xóa thuộc tính',
        icon: <DeleteOutlined />,
        danger: true,
        onClick: (e: any) => { 
          e.domEvent.stopPropagation(); 
          Modal.confirm({
            title: isCore ? 'Cảnh báo: Đây là core field từ schema gốc!' : 'Xác nhận xóa',
            content: `Bạn có chắc chắn muốn xóa thuộc tính này không?${isCore ? ' Hành động này có thể gây lỗi hệ thống.' : ''}`,
            okText: 'Xóa',
            okType: 'danger',
            cancelText: 'Hủy',
            onOk: () => onDeleteAttribute(id)
          });
        }
      });
    }
    return { items };
  };

  const recursivelyBuildTree = (parentId: number | null): DataNode[] => {
    return groups
      .filter(g => (parentId === null ? !g.parentGroupId : g.parentGroupId === parentId))
      .map(group => {
        const groupChildren = recursivelyBuildTree(group.id);
        const attributeChildren = group.attributes.map(attr => ({
          title: attr.name,
          key: `a_${attr.id}`,
          isLeaf: true,
          icon: <FileTextOutlined />,
          customData: { type: 'attribute', id: attr.id, isCore: attr.isCore, dataType: attr.dataType }
        } as DataNode & { customData: any }));

        return {
          title: group.name,
          key: `g_${group.id}`,
          children: [...groupChildren, ...attributeChildren],
          customData: { type: 'group', id: group.id, isCore: group.isCore }
        } as DataNode & { customData: any };
      });
  };

  const treeData = useMemo(() => recursivelyBuildTree(null), [groups]);

  if (groups.length === 0) {
    return <Empty description="Không có nhóm nào trong tầng này" />;
  }

  return (
    <div style={{ paddingTop: 8 }}>
      <Tree
        treeData={treeData}
        showIcon
        blockNode
        selectedKeys={selectedNodeId ? [selectedNodeId] : []}
        onSelect={handleSelect}
        titleRender={(nodeData: any) => {
          const customData = nodeData.customData;
          return (
            <span style={{ display: 'inline-flex', flex: 1, justifyContent: 'space-between', alignItems: 'center', width: '100%', paddingRight: 8 }}>
              <span style={{ fontSize: customData.type === 'group' ? 14 : 13, fontWeight: customData.type === 'group' ? 500 : 'normal' }}>
                {nodeData.title}
                {customData.type === 'attribute' && (
                  <span style={{ marginLeft: 8, fontSize: 11, color: '#888' }}>({customData.dataType})</span>
                )}
                {customData.isCore && (
                  <Tooltip title="Dữ liệu cốt lõi (Không thể xóa)">
                    <LockOutlined style={{ fontSize: 12, marginLeft: 6, color: '#ff4d4f' }} />
                  </Tooltip>
                )}
              </span>
              <Dropdown menu={menuCreator(customData.type, customData.id, customData.isCore)} trigger={['click']}>
                <span onClick={e => e.stopPropagation()} style={{ cursor: 'pointer', padding: '0 4px', float: 'right' }}>
                  <EllipsisOutlined style={{ fontSize: 16, color: '#888' }} />
                </span>
              </Dropdown>
            </span>
          );
        }}
      />
    </div>
  );
}
