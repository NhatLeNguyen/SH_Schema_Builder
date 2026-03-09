import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '../lib/api';
import { message } from 'antd';

export interface SchemaAttribute {
  id: number;
  name: string;
  sqlColumnName: string;
  dataType: string;
  cardinality: string;
  isRequired: boolean;
  defaultValue?: string;
  description: string;
  fkTarget?: string;
  isHidden: boolean;
  hasPermission: boolean;
  scope: string;
  isCore: boolean;
  groupId: number;
}

export interface Group {
  id: number;
  name: string;
  sqlTableName: string;
  cardinality: string;
  description: string;
  isCore: boolean;
  tierId: number;
  parentGroupId?: number | null;
  subGroups?: Group[];
  attributes: SchemaAttribute[];
}

export interface Tier {
  id: number;
  name: string;
  nature: string;
  description: string;
  groups: Group[];
}

export const useTiers = () => {
  return useQuery<Tier[]>({
    queryKey: ['tiers'],
    queryFn: async () => {
      const { data } = await api.get('/schema/tiers');
      return data;
    }
  });
};

export const useGroupMutations = () => {
  const queryClient = useQueryClient();

  const createGroup = useMutation({
    mutationFn: async (group: Partial<Group>) => {
      const { data } = await api.post('/schema/groups', group);
      return data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['tiers'] });
      message.success('Thêm nhóm thành công');
    },
    onError: (err: any) => message.error(err.response?.data?.message || 'Lỗi khi tạo nhóm')
  });

  const updateGroup = useMutation({
    mutationFn: async ({ id, ...group }: Partial<Group> & { id: number }) => {
      await api.put(`/schema/groups/${id}`, { id, ...group });
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['tiers'] });
      message.success('Cập nhật nhóm thành công');
    },
    onError: (err: any) => message.error(err.response?.data?.message || 'Lỗi khi cập nhật nhóm')
  });

  const deleteGroup = useMutation({
    mutationFn: async (id: number) => {
      await api.delete(`/schema/groups/${id}`);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['tiers'] });
      message.success('Xóa nhóm thành công');
    },
    onError: (err: any) => message.error(err.response?.data?.message || 'Lỗi khi xóa nhóm')
  });

  return { createGroup, updateGroup, deleteGroup };
};

export const useAttributeMutations = () => {
  const queryClient = useQueryClient();

  const createAttribute = useMutation({
    mutationFn: async (attribute: Partial<SchemaAttribute>) => {
      const { data } = await api.post('/schema/attributes', attribute);
      return data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['tiers'] });
      message.success('Thêm thuộc tính thành công');
    },
    onError: (err: any) => message.error(err.response?.data?.message || 'Lỗi khi tạo thuộc tính')
  });

  const updateAttribute = useMutation({
    mutationFn: async ({ id, ...attribute }: Partial<SchemaAttribute> & { id: number }) => {
      await api.put(`/schema/attributes/${id}`, { id, ...attribute });
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['tiers'] });
      message.success('Cập nhật thuộc tính thành công');
    },
    onError: (err: any) => message.error(err.response?.data?.message || 'Lỗi khi cập nhật thuộc tính')
  });

  const deleteAttribute = useMutation({
    mutationFn: async (id: number) => {
      await api.delete(`/schema/attributes/${id}`);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['tiers'] });
      message.success('Xóa thuộc tính thành công');
    },
    onError: (err: any) => message.error(err.response?.data?.message || 'Lỗi khi xóa thuộc tính')
  });

  return { createAttribute, updateAttribute, deleteAttribute };
};
