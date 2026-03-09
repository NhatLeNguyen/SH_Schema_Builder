import { useState } from 'react';
import { useAuthStore } from '../store/authStore';
import { api } from '../lib/api';
import { useNavigate } from 'react-router-dom';
import { Button } from '../components/ui/button';
import { Input } from '../components/ui/input';
import { Label } from '../components/ui/label';

export default function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const login = useAuthStore(state => state.login);
  const navigate = useNavigate();

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setLoading(true);

    try {
      const { data } = await api.post('/auth/login', { username, password });
      login(data.accessToken, data.refreshToken, username);
      navigate('/');
    } catch (err: any) {
      setError(err.response?.data?.message || 'Đăng nhập thất bại. Vui lòng thử lại.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-slate-50 dark:bg-slate-900">
      <div className="w-full max-w-md p-8 bg-white rounded-xl shadow-lg dark:bg-slate-800">
        <div className="flex flex-col items-center mb-8">
          <div className="w-12 h-12 mb-4 bg-primary text-primary-foreground rounded-full flex items-center justify-center font-bold text-xl">
            S&H
          </div>
          <h1 className="text-2xl font-bold text-slate-900 dark:text-white">S&H Schema Builder</h1>
          <p className="text-slate-500 text-sm mt-2">Đăng nhập để quản lý cấu trúc dữ liệu</p>
        </div>

        <form onSubmit={handleLogin} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="username">Tên đăng nhập</Label>
            <Input 
              id="username" 
              placeholder="Nhập tên đăng nhập..." 
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              required
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="password">Mật khẩu</Label>
            <Input 
              id="password" 
              type="password" 
              placeholder="••••••••" 
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>

          {error && <p className="text-sm font-medium text-destructive">{error}</p>}

          <Button type="submit" className="w-full mt-4" disabled={loading}>
            {loading ? 'Đang xác thực...' : 'Đăng nhập'}
          </Button>
        </form>
      </div>
    </div>
  );
}
