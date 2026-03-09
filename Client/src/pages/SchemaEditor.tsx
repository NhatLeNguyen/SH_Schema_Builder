import { useState, useMemo } from 'react';
import { Layout, Tabs, Input, Button, Space, Badge, Empty, Modal, Typography, Tooltip, Spin } from 'antd';
import {
  DatabaseOutlined,
  PlusOutlined,
  CodeOutlined,
  SaveOutlined,
  SyncOutlined,
  AppstoreOutlined,
  SettingOutlined,
  CloseOutlined,
  InfoCircleOutlined,
} from '@ant-design/icons';
import { SchemaTree } from '../components/SchemaTree';
import { GroupForm, AttributeForm } from '../components/SchemaForm';
import { SqlPreviewModal } from '../components/SqlPreviewModal';
import { useTiers, useGroupMutations, useAttributeMutations } from '../hooks/useSchema';
import { useEditorStore } from '../store/editorStore';

const { Header, Sider, Content } = Layout;
const { Text, Title } = Typography;

export default function SchemaEditor() {
  const { data: tiers, isLoading } = useTiers();
  const { selectedTierId, setSelectedTierId, selectedNodeId, selectedNodeType, setSelectedNode } = useEditorStore();
  const { createGroup, updateGroup, deleteGroup } = useGroupMutations();
  const { createAttribute, updateAttribute, deleteAttribute } = useAttributeMutations();

  const [isSqlPreviewOpen, setIsSqlPreviewOpen] = useState(false);
  const [createGroupOpen, setCreateGroupOpen] = useState(false);
  const [createAttributeOpen, setCreateAttributeOpen] = useState(false);
  const [targetParentGroupId, setTargetParentGroupId] = useState<number | null>(null);
  const [searchTerm, setSearchTerm] = useState('');

  const selectedTier = tiers?.find(t => t.id === selectedTierId);
  const allGroups = useMemo(() => tiers?.flatMap(t => t.groups) || [], [tiers]);

  const tierTabs = [
    { id: 1, name: 'Định danh cá nhân', nature: 'Cố định' },
    { id: 2, name: 'Pháp lý', nature: 'Ít thay đổi' },
    { id: 3, name: 'BHYT & Quyền lợi', nature: 'Thay đổi định kỳ' },
    { id: 4, name: 'Di truyền bất biến', nature: 'Bất biến' },
    { id: 5, name: 'Sinh học biến động', nature: 'Biến động liên tục' },
  ];

  const handleAddSubGroup = (parentId: number) => {
    setTargetParentGroupId(parentId);
    setCreateGroupOpen(true);
  };

  const handleAddAttribute = (groupId: number) => {
    setTargetParentGroupId(groupId);
    setCreateAttributeOpen(true);
  };

  if (isLoading) {
    return (
      <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
        <Spin size="large" tip="Đang tải cấu trúc dữ liệu..." />
      </div>
    );
  }

  // Extract the actual entity ID from composite tree keys like "g_0_116" or "a_5_42"
  const getEntityId = (key: string | null): number | null => {
    if (!key) return null;
    const parts = key.split('_');
    return Number(parts[parts.length - 1]);
  };

  const entityId = getEntityId(selectedNodeId);
  const currentNode: any = selectedNodeType === 'group'
    ? allGroups.find(g => g.id === entityId)
    : allGroups.flatMap(g => g.attributes).find(a => a?.id === entityId);

  const groups = selectedTier?.groups || [];

  const tabItems = tierTabs.map(tab => {
    const tierData = tiers?.find(t => t.id === tab.id);
    const groupCount = tierData?.groups.length || 0;
    const attrCount = tierData?.groups.reduce((acc, g) => acc + g.attributes.length, 0) || 0;

    return {
      key: String(tab.id),
      label: (
        <Space direction="vertical" size={0} align="center" style={{ padding: '4px 0' }}>
          <Space size={6}>
            <Badge count={tab.id} size="small" style={{ backgroundColor: selectedTierId === tab.id ? '#4f46e5' : '#555' }} />
            <Text strong style={{ fontSize: 13 }}>{tab.name}</Text>
          </Space>
          <Text type="secondary" style={{ fontSize: 10 }}>
            {tab.nature} · {attrCount} tt · {groupCount} nhóm
          </Text>
        </Space>
      ),
    };
  });

  return (
    <Layout style={{ height: '100vh', overflow: 'hidden' }}>
      {/* TOP BAR */}
      <Header style={{
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        padding: '0 24px',
        height: 56,
        borderBottom: '1px solid rgba(0,0,0,0.06)',
        background: '#ffffff',
      }}>
        <Space size={16} align="center">
          <div style={{
            width: 36, height: 36, borderRadius: 10,
            background: 'linear-gradient(135deg, #4f46e5, #3b82f6)',
            display: 'flex', alignItems: 'center', justifyContent: 'center',
            boxShadow: '0 4px 12px rgba(79,70,229,0.3)',
          }}>
            <DatabaseOutlined style={{ fontSize: 18, color: '#fff' }} />
          </div>
          <Title level={5} style={{ margin: 0, letterSpacing: -0.5 }}>S&H — Cấu trúc dữ liệu bệnh nhân</Title>
          <Badge status="success" text={<Text type="secondary" style={{ fontSize: 10 }}>Connected</Text>} />
        </Space>

        <Space size={8}>
          <Button icon={<SaveOutlined />} size="small">Lưu phiên bản</Button>
          <Button icon={<CodeOutlined />} size="small" onClick={() => setIsSqlPreviewOpen(true)}>Xem SQL</Button>
          <Button type="primary" icon={<SyncOutlined />} size="small">Update Cấu trúc</Button>
        </Space>
      </Header>

      <Layout>
        {/* SIDEBAR (TREE) */}
        <Sider
          width={320}
          style={{
            background: '#fafafa',
            borderRight: '1px solid rgba(0,0,0,0.06)',
            height: 'calc(100vh - 56px)',
            overflow: 'hidden',
          }}
        >
          <div style={{ display: 'flex', flexDirection: 'column', height: '100%' }}>
            <div style={{ padding: '16px 16px 8px', flexShrink: 0 }}>
              <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 12 }}>
                <Text type="secondary" style={{ fontSize: 11, fontWeight: 700, textTransform: 'uppercase', letterSpacing: 1.5 }}>
                  Cây dữ liệu
                </Text>
                <Tooltip title="Thêm nhóm gốc">
                  <Button
                    type="text"
                    size="small"
                    icon={<PlusOutlined />}
                    onClick={() => { setTargetParentGroupId(null); setCreateGroupOpen(true); }}
                    style={{ color: '#4f46e5' }}
                  />
                </Tooltip>
              </div>
              <Input.Search
                placeholder="Tìm nhóm, thuộc tính..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                allowClear
                size="middle"
              />
            </div>

            <div className="custom-scrollbar" style={{ flex: 1, overflowY: 'auto', overflowX: 'hidden', padding: '8px 8px 16px' }}>
              <SchemaTree
                groups={groups}
                onAddSubGroup={handleAddSubGroup}
                onAddAttribute={handleAddAttribute}
                onDeleteGroup={(id) => deleteGroup.mutate(id)}
                onDeleteAttribute={(attrId) => deleteAttribute.mutate(attrId)}
                searchTerm={searchTerm}
              />
            </div>
          </div>
        </Sider>

        {/* MAIN CONTENT */}
        <Content style={{ display: 'flex', flexDirection: 'column', minWidth: 0, background: '#f5f5f5' }}>
          {/* Tier Tabs */}
          <Tabs
            activeKey={String(selectedTierId)}
            onChange={(key) => setSelectedTierId(Number(key))}
            items={tabItems}
            centered
            size="large"
            style={{
              background: '#ffffff',
              borderBottom: '1px solid rgba(0,0,0,0.06)',
              margin: 0,
              paddingTop: 4,
            }}
            tabBarStyle={{ marginBottom: 0 }}
          />

          {/* Editor Area */}
          <div className="custom-scrollbar" style={{ flex: 1, overflowY: 'auto', padding: selectedNodeId ? 0 : 48 }}>
            {selectedNodeId ? (
              <div style={{ maxWidth: 900, margin: '0 auto', padding: '48px 32px' }}>
                {/* Node Header */}
                <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'flex-start', marginBottom: 32 }}>
                  <Space size={20} align="start">
                    <div style={{
                      width: 56, height: 56, borderRadius: 20,
                      background: '#4f46e5',
                      display: 'flex', alignItems: 'center', justifyContent: 'center',
                      boxShadow: '0 8px 24px rgba(79,70,229,0.3)',
                    }}>
                      {selectedNodeType === 'group'
                        ? <AppstoreOutlined style={{ fontSize: 28, color: '#fff' }} />
                        : <SettingOutlined style={{ fontSize: 28, color: '#fff' }} />
                      }
                    </div>
                    <div>
                      <Space size={8} align="center">
                        <Title level={3} style={{ margin: 0 }}>{currentNode?.name}</Title>
                        {currentNode?.isCore && (
                          <Badge
                            count="CORE"
                            style={{ backgroundColor: '#ef4444', fontSize: 9, fontWeight: 800 }}
                          />
                        )}
                      </Space>
                      <Text type="secondary" style={{ fontSize: 11, fontWeight: 600, textTransform: 'uppercase', letterSpacing: 2 }}>
                        {selectedNodeType === 'group' ? 'Biên tập Nhóm Dữ liệu' : 'Cấu hình Thuộc tính'} · Tier {selectedTierId}
                      </Text>
                    </div>
                  </Space>
                  <Button
                    type="text"
                    icon={<CloseOutlined />}
                    onClick={() => setSelectedNode(null, null)}
                    danger
                  />
                </div>

                {/* Form Card */}
                <div style={{
                  background: '#fafafa',
                  border: '1px solid rgba(0,0,0,0.06)',
                  borderRadius: 24,
                  padding: 40,
                }}>
                  {selectedNodeType === 'group' && currentNode ? (
                    <GroupForm
                      initialData={currentNode}
                      onSubmit={(values: any) => updateGroup.mutate({ id: (currentNode as any).id, ...values })}
                    />
                  ) : selectedNodeType === 'attribute' && currentNode ? (
                    <AttributeForm
                      initialData={currentNode}
                      parentGroupName={allGroups.find(g => g.attributes.some(a => a.id === (currentNode as any).id))?.name}
                      tierId={selectedTierId}
                      onSubmit={(values: any) => updateAttribute.mutate({ ...(currentNode as any), ...values })}
                    />
                  ) : null}
                </div>

                <div style={{
                  marginTop: 24, padding: '12px 20px', borderRadius: 12,
                  background: 'rgba(79,70,229,0.05)', border: '1px solid rgba(79,70,229,0.1)',
                  display: 'flex', alignItems: 'center', gap: 8,
                }}>
                  <InfoCircleOutlined style={{ color: '#4f46e5' }} />
                  <Text type="secondary" style={{ fontSize: 12, fontStyle: 'italic' }}>
                    Vui lòng kiểm tra kỹ các ràng buộc SQL trước khi lưu thay đổi.
                  </Text>
                </div>
              </div>
            ) : (
              <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', height: '100%', padding: 48 }}>
                <Empty
                  image={<AppstoreOutlined style={{ fontSize: 80, color: 'rgba(79,70,229,0.2)' }} />}
                  description={
                    <div>
                      <Title level={4} style={{ marginTop: 16 }}>Schema Workspace</Title>
                      <Text type="secondary" style={{ maxWidth: 360, display: 'block' }}>
                        Chọn một thành phần từ cây dữ liệu bên trái để bắt đầu thiết lập hoặc tùy chỉnh các tham số chi tiết.
                      </Text>
                    </div>
                  }
                >
                  <Space size={12} style={{ marginTop: 24 }}>
                    <Button
                      icon={<PlusOutlined />}
                      onClick={() => { setTargetParentGroupId(null); setCreateGroupOpen(true); }}
                    >
                      Tạo nhóm mới
                    </Button>
                    <Button
                      type="primary"
                      icon={<CodeOutlined />}
                      onClick={() => setIsSqlPreviewOpen(true)}
                    >
                      Xuất SQL Schema
                    </Button>
                  </Space>
                </Empty>
              </div>
            )}
          </div>
        </Content>
      </Layout>

      {/* Create Group Modal */}
      <Modal
        title={targetParentGroupId ? 'Thêm nhóm con' : 'Tạo nhóm mới'}
        open={createGroupOpen}
        onCancel={() => setCreateGroupOpen(false)}
        footer={null}
        destroyOnClose
      >
        <GroupForm
          initialData={{ tierId: selectedTierId, parentGroupId: targetParentGroupId }}
          onSubmit={(values: any) => {
            createGroup.mutate({ ...values, tierId: selectedTierId, parentGroupId: targetParentGroupId }, {
              onSuccess: () => setCreateGroupOpen(false),
            });
          }}
        />
      </Modal>

      {/* Create Attribute Modal */}
      <Modal
        title="Thêm thuộc tính mới"
        open={createAttributeOpen}
        onCancel={() => setCreateAttributeOpen(false)}
        footer={null}
        destroyOnClose
      >
        <AttributeForm
          initialData={{ groupId: targetParentGroupId }}
          parentGroupName={allGroups.find(g => g.id === targetParentGroupId)?.name}
          tierId={selectedTierId}
          onSubmit={(values: any) => {
            if (targetParentGroupId) {
              createAttribute.mutate({ ...values, groupId: targetParentGroupId }, {
                onSuccess: () => setCreateAttributeOpen(false),
              });
            }
          }}
        />
      </Modal>

      {/* SQL Preview */}
      <SqlPreviewModal
        isOpen={isSqlPreviewOpen}
        onClose={() => setIsSqlPreviewOpen(false)}
        tier={selectedTier}
        allTiers={tiers}
      />
    </Layout>
  );
}
