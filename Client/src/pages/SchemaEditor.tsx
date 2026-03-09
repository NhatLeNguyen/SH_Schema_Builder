import { useState } from 'react';
import { Layout, Menu, Typography, Button, Spin, Card, Empty, Divider, Modal } from 'antd';
import { DatabaseOutlined, ApartmentOutlined, SettingOutlined, PlusOutlined, CodeOutlined } from '@ant-design/icons';
import { SchemaTree } from '../components/SchemaTree';
import { GroupForm, AttributeForm } from '../components/SchemaForm';
import { SqlPreviewModal } from '../components/SqlPreviewModal';
import { useTiers, useGroupMutations, useAttributeMutations } from '../hooks/useSchema';
import { useEditorStore } from '../store/editorStore';

const { Header, Sider, Content } = Layout;
const { Title, Text } = Typography;

export default function SchemaEditor() {
  const { data: tiers, isLoading } = useTiers();
  const { selectedTierId, setSelectedTierId, selectedNodeId, selectedNodeType } = useEditorStore();
  const { createGroup, updateGroup, deleteGroup } = useGroupMutations();
  const { createAttribute, updateAttribute, deleteAttribute } = useAttributeMutations();

  const [isSqlPreviewOpen, setIsSqlPreviewOpen] = useState(false);
  const [createGroupOpen, setCreateGroupOpen] = useState(false);
  const [createAttributeOpen, setCreateAttributeOpen] = useState(false);
  const [targetParentGroupId, setTargetParentGroupId] = useState<number | null>(null);

  const selectedTier = tiers?.find(t => t.id === selectedTierId);
  const groups = selectedTier?.groups || [];

  const handleAddSubGroup = (parentId: number) => {
    setTargetParentGroupId(parentId);
    setCreateGroupOpen(true);
  };

  const handleAddAttribute = (groupId: number) => {
    setTargetParentGroupId(groupId);
    setCreateAttributeOpen(true);
  };

  if (isLoading) return <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><Spin size="large" /></div>;

  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Header style={{ display: 'flex', alignItems: 'center', background: '#fff', borderBottom: '1px solid #f0f0f0', padding: '0 24px' }}>
        <DatabaseOutlined style={{ fontSize: 24, color: '#1890ff', marginRight: 16 }} />
        <Title level={4} style={{ margin: 0 }}>S&H Schema Builder</Title>
      </Header>

      <Layout style={{ overflow: 'auto' }}>
        {/* Sidebar: Tier Selection */}
        <Sider width={250} theme="light" style={{ borderRight: '1px solid #f0f0f0' }}>
          <div style={{ padding: '16px' }}>
            <Text type="secondary" strong>TẦNG DỮ LIỆU (TIERS)</Text>
          </div>
          <Menu
            mode="inline"
            selectedKeys={[selectedTierId.toString()]}
            onSelect={({ key }: any) => setSelectedTierId(Number(key))}
            items={tiers?.map(tier => {
              const groupCount = tier.groups?.length || 0;
              const attrCount = tier.groups?.reduce((acc, g) => acc + (g.attributes?.length || 0), 0) || 0;
              return {
                key: tier.id.toString(),
                icon: <ApartmentOutlined />,
                label: (
                  <div style={{ display: 'flex', flexDirection: 'column', lineHeight: '1.2' }}>
                    <span style={{ fontWeight: 500 }}>{tier.name}</span>
                    <span style={{ fontSize: 11, color: '#888' }}>{groupCount} nhóm, {attrCount} tt</span>
                  </div>
                ),
                style: { height: 'auto', padding: '12px 16px' }
              };
            })}
          />
        </Sider>

        {/* Center: Tree View */}
        <Content style={{ padding: '24px', background: '#fafafa', borderRight: '1px solid #f0f0f0', width: 400, flex: '0 0 400px', display: 'flex', flexDirection: 'column' }}>
          <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 16 }}>
            <Title level={5} style={{ margin: 0 }}>Cấu trúc: {selectedTier?.name}</Title>
            <div>
               <Button type="primary" icon={<PlusOutlined />} size="small" onClick={() => { setTargetParentGroupId(null); setCreateGroupOpen(true); }} style={{ marginRight: 8 }}>
                 Nhóm mới
               </Button>
               <Button icon={<CodeOutlined />} size="small" onClick={() => setIsSqlPreviewOpen(true)}>
                 SQL
               </Button>
            </div>
          </div>
          <Card bodyStyle={{ padding: '4px' }} style={{ flex: 1, overflowY: 'auto' }}>
            <SchemaTree 
              groups={groups} 
              tierId={selectedTierId}
              onAddSubGroup={handleAddSubGroup}
              onAddAttribute={handleAddAttribute}
              onDeleteGroup={(id) => deleteGroup.mutate(id)}
              onDeleteAttribute={(id) => deleteAttribute.mutate(id)}
            />
          </Card>
        </Content>

        {/* Right: Property Editor */}
        <Sider width={450} theme="light" style={{ padding: '24px', background: '#fff', overflowY: 'auto' }}>
          <div style={{ marginBottom: 24, display: 'flex', alignItems: 'center' }}>
            <SettingOutlined style={{ fontSize: 20, marginRight: 8 }} />
            <Title level={5} style={{ margin: 0 }}>Thuộc Tính Chi Tiết</Title>
          </div>

          <Divider />

          {!selectedNodeId ? (
            <Empty description="Chọn một nhóm hoặc thuộc tính để chỉnh sửa" style={{ marginTop: 60 }} />
          ) : (
            <div>
              {selectedNodeType === 'group' && (
                <GroupForm 
                  key={`group_${selectedNodeId}`}
                  initialData={groups.find(g => `g_${g.id}` === selectedNodeId) || {}} 
                  onSubmit={(values) => {
                    const id = Number(selectedNodeId?.replace('g_', ''));
                    const currentGroup = groups.find(g => `g_${g.id}` === selectedNodeId);
                    if (currentGroup?.isCore) {
                      Modal.confirm({
                        title: 'Cảnh báo: Đây là core field từ schema gốc!',
                        content: 'Sửa đổi cấu trúc lõi có thể ảnh hưởng đến logic hệ thống. Bạn thực sự muốn tiếp tục?',
                        onOk: () => updateGroup.mutate({ id, ...values })
                      });
                    } else {
                      updateGroup.mutate({ id, ...values });
                    }
                  }} 
                />
              )}
              {selectedNodeType === 'attribute' && (
                <AttributeForm 
                  key={`attr_${selectedNodeId}`}
                  initialData={groups.flatMap(g => g.attributes).find(a => `a_${a?.id}` === selectedNodeId) || {}} 
                  parentGroupName={groups.find(g => g.attributes?.some(a => `a_${a?.id}` === selectedNodeId))?.name}
                  tierId={selectedTierId}
                  onSubmit={(values) => {
                    const id = Number(selectedNodeId?.replace('a_', ''));
                    const currentAttr = groups.flatMap(g => g.attributes).find(a => a?.id === id);
                    if (currentAttr) {
                      if (currentAttr.isCore) {
                        Modal.confirm({
                          title: 'Cảnh báo: Đây là core field từ schema gốc!',
                          content: 'Sửa đổi thuộc tính lõi có thể làm gián đoạn hệ thống. Tiếp tục?',
                          onOk: () => updateAttribute.mutate({ ...currentAttr, ...values })
                        });
                      } else {
                        updateAttribute.mutate({ ...currentAttr, ...values });
                      }
                    }
                  }} 
                />
              )}
            </div>
          )}
        </Sider>
      </Layout>

      <Modal title={targetParentGroupId ? "Thêm Nhóm Con" : "Thêm Nhóm Mới"} open={createGroupOpen} onCancel={() => setCreateGroupOpen(false)} footer={null} destroyOnClose>
        <GroupForm 
          initialData={{ tierId: selectedTierId, parentGroupId: targetParentGroupId }}
          onSubmit={(values) => {
            createGroup.mutate({ ...values, tierId: selectedTierId, parentGroupId: targetParentGroupId }, {
              onSuccess: () => setCreateGroupOpen(false)
            });
          }} 
        />
      </Modal>

      <Modal title="Thêm Thuộc Tính" open={createAttributeOpen} onCancel={() => setCreateAttributeOpen(false)} footer={null} destroyOnClose>
        <AttributeForm
          initialData={{ groupId: targetParentGroupId }}
          parentGroupName={groups.find(g => g.id === targetParentGroupId)?.name}
          tierId={selectedTierId}
          onSubmit={(values) => {
            if (targetParentGroupId) {
              createAttribute.mutate({ ...values, groupId: targetParentGroupId }, {
                onSuccess: () => setCreateAttributeOpen(false)
              });
            }
          }}
        />
      </Modal>

      <SqlPreviewModal
        isOpen={isSqlPreviewOpen}
        onClose={() => setIsSqlPreviewOpen(false)}
        tier={selectedTier}
      />
    </Layout>
  );
}
