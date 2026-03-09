import { create } from 'zustand';

export interface EditorState {
  selectedTierId: number;
  selectedNodeId: string | null;
  selectedNodeType: 'group' | 'attribute' | null;
  setSelectedTierId: (id: number) => void;
  setSelectedNode: (id: string | null, type: 'group' | 'attribute' | null) => void;
}

export const useEditorStore = create<EditorState>((set) => ({
  selectedTierId: 5,
  selectedNodeId: null,
  selectedNodeType: null,
  setSelectedTierId: (id) => set({ selectedTierId: id, selectedNodeId: null, selectedNodeType: null }),
  setSelectedNode: (id, type) => set({ selectedNodeId: id, selectedNodeType: type })
}));
