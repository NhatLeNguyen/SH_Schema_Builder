import { useMemo, useEffect, useState, type MouseEvent } from 'react';
import { useEditorStore } from '../store/editorStore';
import type { Group } from '../hooks/useSchema';
import { 
  Folder, 
  ChevronRight, 
  ChevronDown, 
  Plus, 
  Trash2, 
  Lock,
  FileText,
  Database,
  Sparkles
} from 'lucide-react';
import { cn } from '../lib/utils';

interface SchemaTreeProps {
  groups: Group[];
  onAddSubGroup: (parentGroupId: number) => void;
  onAddAttribute: (groupId: number) => void;
  onDeleteGroup: (groupId: number) => void;
  onDeleteAttribute: (attributeId: number) => void;
  searchTerm?: string;
}

const TreeNode = ({ 
  item, 
  level = 0, 
  onAddSubGroup, 
  onAddAttribute, 
  onDeleteGroup, 
  onDeleteAttribute,
  searchTerm 
}: { 
  item: any, 
  level?: number,
  onAddSubGroup: any,
  onAddAttribute: any,
  onDeleteGroup: any,
  onDeleteAttribute: any,
  searchTerm?: string
}) => {
  const [isOpen, setIsOpen] = useState(level < 1 || !!searchTerm);
  const { selectedNodeId, setSelectedNode } = useEditorStore();
  
  const isSelected = selectedNodeId === (item.attributes ? `g_${item.id}` : `a_${item.id}`);
  const isGroup = !!item.attributes;
  const isCore = !!item.isCore;

  // Re-open if searching
  useEffect(() => {
    if (searchTerm) setIsOpen(true);
  }, [searchTerm]);

  const handleToggle = (e: MouseEvent) => {
    e.stopPropagation();
    setIsOpen(!isOpen);
  };

  const handleSelect = (e: MouseEvent) => {
    e.stopPropagation();
    setSelectedNode(
      isGroup ? `g_${item.id}` : `a_${item.id}`,
      isGroup ? 'group' : 'attribute'
    );
  };

  return (
    <div className="select-none animate-in fade-in slide-in-from-left-2 duration-500">
      <div 
        onClick={handleSelect}
        className={cn(
          "group flex items-center gap-2.5 py-2.5 px-3 rounded-2xl cursor-pointer transition-all duration-300 mb-1 border relative overflow-hidden",
          isSelected 
            ? "bg-primary/10 text-primary border-primary/30 shadow-lg shadow-primary/5" 
            : "hover:bg-accent/40 text-muted-foreground/80 hover:text-foreground border-transparent hover:border-border/60 hover:translate-x-1"
        )}
        style={{ paddingLeft: `${(level * 0.75) + 0.75}rem` }}
      >
        {/* Selection Glow */}
        {isSelected && (
          <div className="absolute inset-0 bg-gradient-to-r from-primary/5 to-transparent pointer-events-none" />
        )}

        <div className="flex items-center gap-2.5 flex-1 min-w-0 z-10">
          {isGroup ? (
            <button 
              onClick={handleToggle}
              className={cn(
                "p-1 hover:bg-black/5 dark:hover:bg-white/5 rounded-lg transition-transform duration-300",
                isOpen && "rotate-0",
                !isOpen && "-rotate-0"
              )}
            >
              {isOpen ? <ChevronDown size={14} className="opacity-40" /> : <ChevronRight size={14} className="opacity-40" />}
            </button>
          ) : (
            <div className="w-6" />
          )}
          
          <div className={cn(
              "p-2 rounded-xl shrink-0 transition-all duration-500",
              isSelected 
                ? "bg-primary text-white shadow-lg shadow-primary/30 rotate-hover" 
                : isGroup ? "bg-amber-500/10 text-amber-500 group-hover:bg-amber-500 group-hover:text-white" : "bg-blue-500/10 text-blue-500 group-hover:bg-blue-500 group-hover:text-white"
          )}>
            {isGroup ? <Folder size={14} strokeWidth={2.5} /> : <FileText size={14} strokeWidth={2.5} />}
          </div>
          
          <div className="flex flex-col min-w-0">
            <span className={cn(
              "truncate text-[13px] font-bold tracking-tight transition-colors",
              isSelected ? "text-primary" : "group-hover:text-foreground"
            )}>
              {item.name}
            </span>
            {isGroup && (
               <span className="text-[9px] opacity-40 font-mono tracking-tighter truncate uppercase group-hover:opacity-60 transition-opacity">
                 {item.sqlTableName}
               </span>
            )}
          </div>
          
          {isCore && (
            <div className="p-1 rounded-full bg-destructive/10 text-destructive ml-auto">
              <Lock size={10} strokeWidth={3} />
            </div>
          )}
        </div>

        <div className="opacity-0 group-hover:opacity-100 flex items-center gap-1.5 transition-all duration-300 z-10 translate-x-2 group-hover:translate-x-0">
          {isGroup && (
            <button 
              onClick={(e) => { e.stopPropagation(); onAddAttribute(item.id); }}
              className="p-1.5 hover:bg-primary/20 rounded-xl text-primary transition-colors bg-background/50 border border-border/40"
              title="Thêm thuộc tính"
            >
              <Plus size={14} strokeWidth={2.5} />
            </button>
          )}
          <button 
            onClick={(e) => { 
                e.stopPropagation(); 
                if (isCore) {
                  if (confirm('Cảnh báo: Đây là core field từ schema gốc! Bạn vẫn muốn tiếp tục xóa?')) {
                    if (isGroup) onDeleteGroup(item.id); else onDeleteAttribute(item.id);
                  }
                } else {
                  if (isGroup) onDeleteGroup(item.id); else onDeleteAttribute(item.id);
                }
            }}
            className={cn(
                "p-1.5 hover:bg-destructive/20 rounded-xl transition-colors bg-background/50 border border-border/40",
                isCore ? "text-destructive/30 hover:text-destructive" : "text-destructive/60 hover:text-destructive"
            )}
            title="Xóa"
          >
            <Trash2 size={14} strokeWidth={2.5} />
          </button>
        </div>
      </div>

      {isGroup && isOpen && (
        <div className="ml-3 border-l-2 border-border/30 pl-3 mt-1 space-y-1 animate-in slide-in-from-top-1 duration-300">
          {item.subGroups && item.subGroups.map((sub: any) => (
            <TreeNode 
              key={`g_${sub.id}`} 
              item={sub} 
              level={level + 1}
              onAddSubGroup={onAddSubGroup}
              onAddAttribute={onAddAttribute}
              onDeleteGroup={onDeleteGroup}
              onDeleteAttribute={onDeleteAttribute}
              searchTerm={searchTerm}
            />
          ))}
          {item.attributes && item.attributes.map((attr: any) => (
             <TreeNode 
               key={`a_${attr.id}`} 
               item={attr} 
               level={level + 1}
               onAddSubGroup={onAddSubGroup}
               onAddAttribute={onAddAttribute}
               onDeleteGroup={onDeleteGroup}
               onDeleteAttribute={onDeleteAttribute}
               searchTerm={searchTerm}
             />
          ))}
        </div>
      )}
    </div>
  );
};

export function SchemaTree({ groups, onAddSubGroup, onAddAttribute, onDeleteGroup, onDeleteAttribute, searchTerm }: SchemaTreeProps) {
  const filteredData = useMemo(() => {
     if (!searchTerm) return groups;

     const term = searchTerm.toLowerCase();
     // Simple filter logic: keep groups that match or have matching attributes
     return groups.filter(g => 
        g.name.toLowerCase().includes(term) || 
        (g.attributes && g.attributes.some(a => a.name.toLowerCase().includes(term))) ||
        (g.subGroups && g.subGroups.some((sg: any) => sg.name.toLowerCase().includes(term)))
     );
  }, [groups, searchTerm]);

  if (groups.length === 0) {
    return (
      <div className="flex flex-col items-center justify-center py-16 px-6 text-muted-foreground bg-accent/10 rounded-[2.5rem] border-2 border-dashed border-border/40 group cursor-default">
        <div className="relative mb-4">
           <Database className="w-12 h-12 opacity-20 group-hover:opacity-40 transition-opacity duration-700" />
           <Sparkles className="absolute top-0 right-0 w-4 h-4 text-primary opacity-0 group-hover:opacity-100 transition-opacity animate-pulse" />
        </div>
        <p className="text-[10px] font-black uppercase tracking-[0.2em] text-center opacity-40">Hệ thống chưa có dữ liệu</p>
      </div>
    );
  }

  return (
    <div className="space-y-1.5 px-1 py-2">
      {filteredData.map(group => (
        <TreeNode 
          key={`g_${group.id}`} 
          item={group} 
          onAddSubGroup={onAddSubGroup}
          onAddAttribute={onAddAttribute}
          onDeleteGroup={onDeleteGroup}
          onDeleteAttribute={onDeleteAttribute}
          searchTerm={searchTerm}
        />
      ))}
    </div>
  );
}
