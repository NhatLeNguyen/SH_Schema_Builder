import { useState, useMemo } from 'react';
import { 
  Database, 
  Layers, 
  Settings, 
  Plus, 
  Code, 
  Search,
  LayoutDashboard,
  Box,
  X,
  Save,
  RefreshCw,
  Info
} from 'lucide-react';
import { SchemaTree } from '../components/SchemaTree';
import { GroupForm, AttributeForm } from '../components/SchemaForm';
import { SqlPreviewModal } from '../components/SqlPreviewModal';
import { useTiers, useGroupMutations, useAttributeMutations } from '../hooks/useSchema';
import { useEditorStore } from '../store/editorStore';
import { cn } from '../lib/utils';

const CustomModal = ({ isOpen, onClose, title, children }: any) => {
  if (!isOpen) return null;
  return (
    <div className="fixed inset-0 z-[60] flex items-center justify-center p-4 bg-black/40 backdrop-blur-sm animate-in fade-in duration-200">
      <div className="bg-background border border-border rounded-xl shadow-xl w-full max-w-md animate-in zoom-in-95 duration-200">
        <div className="p-4 border-b border-border flex items-center justify-between">
          <h3 className="font-bold">{title}</h3>
          <button onClick={onClose} className="p-1 hover:bg-muted rounded-lg transition-all"><X size={18} /></button>
        </div>
        <div className="p-6">{children}</div>
      </div>
    </div>
  );
};

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
  
  // Tab Metadata
  const tierTabs = [
    { id: 1, name: "Định danh cá nhân", nature: "Cố định" },
    { id: 2, name: "Pháp lý", nature: "Ít thay đổi" },
    { id: 3, name: "BHYT & Quyền lợi", nature: "Thay đổi định kỳ" },
    { id: 4, name: "Di truyền bất biến", nature: "Bất biến" },
    { id: 5, name: "Sinh học biến động", nature: "Biến động liên tục" },
  ];

  const handleAddSubGroup = (parentId: number) => {
    setTargetParentGroupId(parentId);
    setCreateGroupOpen(true);
  };

  const handleAddAttribute = (groupId: number) => {
    setTargetParentGroupId(groupId);
    setCreateAttributeOpen(true);
  };

  if (isLoading) return (
    <div className="flex flex-col items-center justify-center h-screen gap-4">
      <div className="w-12 h-12 border-4 border-primary/20 border-t-primary rounded-full animate-spin" />
      <p className="text-sm font-medium animate-pulse text-muted-foreground">Đang tải cấu trúc dữ liệu...</p>
    </div>
  );

  const currentNode: any = selectedNodeType === 'group' 
    ? allGroups.find(g => `g_${g.id}` === selectedNodeId) 
    : allGroups.flatMap(g => g.attributes).find(a => `a_${a?.id}` === selectedNodeId);

  const groups = selectedTier?.groups || [];

  return (
    <div className="flex flex-col h-screen bg-background text-foreground overflow-hidden font-sans selection:bg-primary/20">
      
      {/* TOP BAR */}
      <header className="h-14 border-b border-border bg-card/50 backdrop-blur-xl px-6 flex items-center justify-between shrink-0 z-50">
        <div className="flex items-center gap-4">
          <div className="flex items-center gap-2.5">
            <div className="w-8 h-8 rounded-lg bg-gradient-to-br from-primary to-blue-600 shadow-lg shadow-primary/20 flex items-center justify-center text-white">
              <Database size={18} strokeWidth={2.5} />
            </div>
            <h1 className="font-bold text-base tracking-tight hidden sm:block">S&H — Cấu trúc dữ liệu bệnh nhân</h1>
          </div>
          <div className="h-4 w-px bg-border/60 mx-2 hidden sm:block" />
          <div className="flex items-center gap-1.5 px-2 py-1 rounded-full bg-accent/30 border border-border/40 hidden md:flex">
             <div className="w-2 h-2 rounded-full bg-emerald-500 animate-pulse" />
             <span className="text-[10px] font-bold uppercase tracking-wider opacity-60">Database Connected</span>
          </div>
        </div>

        <div className="flex items-center gap-2">
          <button className="flex items-center gap-2 px-3 py-1.5 rounded-lg hover:bg-accent text-xs font-semibold transition-all hover:scale-105 active:scale-95">
            <Save size={14} />
            <span className="hidden lg:inline">Lưu phiên bản</span>
          </button>
          <button 
            onClick={() => setIsSqlPreviewOpen(true)}
            className="flex items-center gap-2 px-3 py-1.5 rounded-lg hover:bg-accent text-xs font-semibold transition-all hover:scale-105 active:scale-95"
          >
            <Code size={14} />
            <span className="hidden lg:inline">Xem SQL</span>
          </button>
          <button className="flex items-center gap-2 px-4 py-1.5 rounded-lg bg-primary text-white text-xs font-bold shadow-lg shadow-primary/20 hover:scale-[1.05] active:scale-95 transition-all">
            <RefreshCw size={14} />
            <span className="hidden lg:inline">Update Cấu trúc</span>
          </button>
        </div>
      </header>

      {/* MAIN LAYOUT: 2 COLUMNS */}
      <div className="flex-1 flex overflow-hidden">
        
        {/* COLUMN 1: SIDEBAR (TREE) */}
        <aside className="w-80 border-r border-border bg-card/20 flex flex-col shrink-0">
          <div className="p-4 space-y-4">
             <div className="flex items-center justify-between">
               <h3 className="text-xs font-bold uppercase tracking-widest opacity-50 flex items-center gap-2">
                 <Layers size={12} /> Cây dữ liệu
               </h3>
               <button 
                 onClick={() => { setTargetParentGroupId(null); setCreateGroupOpen(true); }}
                 className="p-1 hover:bg-primary/10 text-primary rounded-md transition-all hover:scale-110 active:scale-90"
                 title="Thêm nhóm gốc"
               >
                 <Plus size={16} />
               </button>
             </div>
             
             <div className="relative group">
               <Search className="absolute left-3 top-2.5 size-4 text-muted-foreground opacity-40 group-focus-within:opacity-100 transition-opacity" />
               <input 
                 value={searchTerm}
                 onChange={(e) => setSearchTerm(e.target.value)}
                 placeholder="Tìm nhóm, thuộc tính..." 
                 className="w-full bg-black/5 dark:bg-white/5 border border-border/40 rounded-xl pl-9 py-2 text-sm outline-none focus:ring-2 focus:ring-primary/20 transition-all font-medium hover:border-border/80"
               />
             </div>
          </div>

          <div className="flex-1 overflow-y-auto px-2 pb-4 custom-scrollbar">
            <SchemaTree 
              groups={groups}
              onAddSubGroup={handleAddSubGroup}
              onAddAttribute={handleAddAttribute}
              onDeleteGroup={(id) => deleteGroup.mutate(id)}
              onDeleteAttribute={(attrId) => deleteAttribute.mutate(attrId)}
              searchTerm={searchTerm}
            />
          </div>
        </aside>

        {/* COLUMN 2: EDITOR CONTENT */}
        <main className="flex-1 flex flex-col min-w-0 bg-accent/5">
           {/* Tier Tabs Navigation */}
           <div className="px-6 border-b border-border bg-card/40 backdrop-blur-md sticky top-0 z-10 overflow-x-auto no-scrollbar shrink-0 shadow-sm">
             <div className="flex items-center gap-1 min-w-max h-16">
                {tierTabs.map(tab => {
                  const tierData = tiers?.find(t => t.id === tab.id);
                  const groupCount = tierData?.groups.length || 0;
                  const attrCount = tierData?.groups.reduce((acc, g) => acc + g.attributes.length, 0) || 0;
                  const isActive = selectedTierId === tab.id;

                  return (
                    <button
                      key={tab.id}
                      onClick={() => setSelectedTierId(tab.id)}
                      className={cn(
                        "relative px-4 py-2 rounded-xl transition-all duration-300 flex flex-col items-center gap-0.5 group shrink-0",
                        isActive 
                          ? "bg-primary/10 text-primary" 
                          : "text-muted-foreground hover:bg-accent/60"
                      )}
                    >
                      <div className="flex items-center gap-2">
                        <span className={cn(
                          "text-[9px] font-black w-3.5 h-3.5 rounded-full flex items-center justify-center border transition-all duration-300",
                          isActive ? "bg-primary text-white border-primary rotate-[360deg]" : "border-border/60"
                        )}>{tab.id}</span>
                        <span className="text-[13px] font-bold tracking-tight whitespace-nowrap">{tab.name}</span>
                      </div>
                      <div className="flex items-center gap-3 text-[8px] font-bold uppercase tracking-tighter opacity-50 group-hover:opacity-100 transition-opacity">
                         <span>{tab.nature}</span>
                         <span className="opacity-30">|</span>
                         <span className="text-primary/80">{attrCount} tt - {groupCount} nhóm</span>
                      </div>
                      {isActive && (
                        <div className="absolute bottom-[-1px] left-4 right-4 h-0.5 bg-primary rounded-t-full shadow-[0_-1px_4px_rgba(var(--primary),0.8)]" />
                      )}
                    </button>
                  );
                })}
             </div>
           </div>

           {/* Editor Content Area */}
           <div className="flex-1 overflow-y-auto custom-scrollbar bg-[radial-gradient(circle_at_top_right,var(--primary-foreground),transparent)] dark:bg-[radial-gradient(circle_at_top_right,var(--accent),transparent)]">
              {selectedNodeId ? (
                <div className="max-w-4xl mx-auto p-8 lg:p-12 animate-in fade-in slide-in-from-bottom-4 duration-500">
                  <div className="mb-10 flex items-center justify-between">
                    <div className="flex items-center gap-5">
                      <div className="p-4 rounded-3xl bg-primary shadow-2xl shadow-primary/30 text-white animate-in zoom-in-50 duration-500 rotate-hover">
                        {selectedNodeType === 'group' ? <Box size={28} strokeWidth={2.5} /> : <Settings size={28} strokeWidth={2.5} />}
                      </div>
                      <div className="min-w-0">
                        <div className="flex items-center gap-3 mb-1">
                          <h2 className="text-3xl font-black tracking-tighter truncate">{currentNode?.name}</h2>
                          {currentNode?.isCore && (
                             <span className="px-2 py-0.5 rounded-full bg-destructive/10 text-destructive text-[9px] font-black uppercase tracking-widest border border-destructive/20 animate-pulse">Core System</span>
                          )}
                        </div>
                        <p className="text-[11px] text-muted-foreground font-bold uppercase tracking-[0.2em] opacity-60">
                          {selectedNodeType === 'group' ? 'Biên tập Nhóm Dữ liệu' : 'Cấu hình Thuộc tính Chi tiết'} · Tier {selectedTierId}
                        </p>
                      </div>
                    </div>
                    
                    <div className="flex items-center gap-2">
                        <button 
                          onClick={() => setSelectedNode(null, null)}
                          className="p-2 hover:bg-destructive/10 hover:text-destructive rounded-xl transition-all"
                          title="Đóng trình biên tập"
                        >
                          <X size={20} />
                        </button>
                    </div>
                  </div>

                  <div className="bg-card border border-border/60 rounded-[2.5rem] shadow-2xl shadow-black/5 overflow-hidden transition-all hover:border-primary/20 hover:shadow-primary/5">
                     <div className="p-10">
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
                  </div>
                  
                  <div className="mt-8 flex items-center gap-2 px-6 py-4 rounded-2xl bg-accent/30 border border-border/40 text-muted-foreground/60">
                    <Info size={16} />
                    <p className="text-xs font-medium italic">Vui lòng kiểm tra kỹ các ràng buộc SQL (Data Type, Nullable) trước khi lưu thay đổi.</p>
                  </div>
                </div>
              ) : (
                <div className="h-full flex flex-col items-center justify-center p-10 text-center select-none animate-in fade-in duration-1000">
                  <div className="relative mb-8 group cursor-default">
                    <div className="absolute inset-0 bg-primary/20 blur-[100px] rounded-full group-hover:bg-primary/30 transition-all duration-1000" />
                    <LayoutDashboard size={120} className="stroke-[0.3px] text-primary/40 group-hover:text-primary/60 transition-all duration-700 hover:rotate-6" />
                  </div>
                  <h3 className="text-3xl font-black tracking-tighter mb-4 bg-gradient-to-br from-foreground to-foreground/40 bg-clip-text text-transparent italic">Schema Workspace</h3>
                  <p className="text-muted-foreground font-medium max-w-sm leading-relaxed mb-8">
                    Chọn một thành phần từ cấu trúc dữ liệu bên trái để bắt đầu thiết lập hoặc tùy chỉnh các tham số chi tiết của hệ thống.
                  </p>
                  
                  <div className="grid grid-cols-2 gap-4 w-full max-w-md">
                     <div className="p-6 rounded-3xl bg-card border border-border/40 hover:border-primary/40 transition-all hover:scale-105 active:scale-95 group cursor-pointer" onClick={() => { setTargetParentGroupId(null); setCreateGroupOpen(true); }}>
                        <div className="w-10 h-10 rounded-2xl bg-primary/10 flex items-center justify-center text-primary mb-3 group-hover:bg-primary group-hover:text-white transition-all">
                           <Box size={20} />
                        </div>
                        <h4 className="font-bold text-sm mb-1">Tạo nhóm mới</h4>
                        <p className="text-[10px] opacity-50">Thêm một phân đoạn dữ liệu chính vào tầng hiện tại.</p>
                     </div>
                     <div className="p-6 rounded-3xl bg-card border border-border/40 hover:border-primary/40 transition-all hover:scale-105 active:scale-95 group cursor-pointer" onClick={() => setIsSqlPreviewOpen(true)}>
                        <div className="w-10 h-10 rounded-2xl bg-blue-500/10 flex items-center justify-center text-blue-500 mb-3 group-hover:bg-blue-500 group-hover:text-white transition-all">
                           <Code size={20} />
                        </div>
                        < h4 className="font-bold text-sm mb-1">Xuất SQL Schema</h4>
                        <p className="text-[10px] opacity-50">Tạo script DDL cho cơ sở dữ liệu vật lý.</p>
                     </div>
                  </div>
                </div>
              )}
           </div>
        </main>
      </div>

      {/* Modals */}
      <CustomModal 
        isOpen={createGroupOpen} 
        onClose={() => setCreateGroupOpen(false)} 
        title={targetParentGroupId ? "Thêm nhóm con" : "Tạo nhóm mới"}
      >
        <GroupForm 
          initialData={{ tierId: selectedTierId, parentGroupId: targetParentGroupId }}
          onSubmit={(values: any) => {
             createGroup.mutate({ ...values, tierId: selectedTierId, parentGroupId: targetParentGroupId }, {
               onSuccess: () => setCreateGroupOpen(false)
             });
          }}
        />
      </CustomModal>

      <CustomModal 
        isOpen={createAttributeOpen} 
        onClose={() => setCreateAttributeOpen(false)} 
        title="Thêm thuộc tính mới"
      >
        <AttributeForm 
          initialData={{ groupId: targetParentGroupId }}
          parentGroupName={allGroups.find(g => g.id === targetParentGroupId)?.name}
          tierId={selectedTierId}
          onSubmit={(values: any) => {
             if (targetParentGroupId) {
               createAttribute.mutate({ ...values, groupId: targetParentGroupId }, {
                 onSuccess: () => setCreateAttributeOpen(false)
               });
             }
          }}
        />
      </CustomModal>

      <SqlPreviewModal 
        isOpen={isSqlPreviewOpen} 
        onClose={() => setIsSqlPreviewOpen(false)} 
        tier={selectedTier}
        allTiers={tiers} 
      />
    </div>
  );
}
