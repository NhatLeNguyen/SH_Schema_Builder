import { create } from 'zustand';

interface AuthState {
  isAuthenticated: boolean;
  username: string | null;
  login: (accessToken: string, refreshToken: string, username: string) => void;
  logout: () => void;
}

export const useAuthStore = create<AuthState>((set) => ({
  isAuthenticated: !!localStorage.getItem('accessToken'),
  username: localStorage.getItem('username'),
  login: (accessToken, refreshToken, username) => {
    localStorage.setItem('accessToken', accessToken);
    localStorage.setItem('refreshToken', refreshToken);
    localStorage.setItem('username', username);
    set({ isAuthenticated: true, username });
  },
  logout: () => {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('username');
    set({ isAuthenticated: false, username: null });
  },
}));
