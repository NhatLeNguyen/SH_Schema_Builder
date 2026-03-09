import { useState } from 'react';
import { useAuthStore } from '../store/authStore';
import { api } from '../lib/api';
import { useNavigate } from 'react-router-dom';
import { Button, Input, Label } from '../components/ui';
import { Database, Lock, User, AlertCircle } from 'lucide-react';

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
    <div className="flex items-center justify-center min-h-screen bg-slate-50 dark:bg-slate-950 p-4 transition-colors duration-500">
      <div className="w-full max-w-md p-8 bg-white/80 dark:bg-slate-900/80 backdrop-blur-xl rounded-3xl shadow-2xl border border-white/20 dark:border-slate-800/50 animate-in fade-in zoom-in-95 duration-700">
        
        <div className="flex flex-col items-center mb-10">
          <div className="w-16 h-16 mb-4 bg-gradient-to-br from-primary to-blue-600 rounded-2xl flex items-center justify-center text-white shadow-xl shadow-primary/30 rotate-3 transition-transform hover:rotate-0 duration-300">
            <Database size={32} strokeWidth={2.5} />
          </div>
          <h1 className="text-3xl font-black text-slate-900 dark:text-white tracking-tighter">S&H — Builder</h1>
          <p className="text-slate-500 text-sm mt-2 font-medium">Bắt đầu thiết kế cấu trúc dữ liệu của bạn</p>
        </div>

        <form onSubmit={handleLogin} className="space-y-6">
          <div className="space-y-2.5">
            <Label htmlFor="username" className="text-[10px] font-bold uppercase tracking-widest opacity-60 flex items-center gap-2 px-1">
              <User size={12} /> Tên đăng nhập
            </Label>
            <Input 
              id="username" 
              placeholder="admin" 
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              required
              className="bg-slate-100/50 dark:bg-slate-800/50 border-transparent focus:border-primary/50 h-12 rounded-xl transition-all"
            />
          </div>
          
          <div className="space-y-2.5">
            <Label htmlFor="password" className="text-[10px] font-bold uppercase tracking-widest opacity-60 flex items-center gap-2 px-1">
              <Lock size={12} /> Mật khẩu
            </Label>
            <Input 
              id="password" 
              type="password" 
              placeholder="••••••••" 
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
              className="bg-slate-100/50 dark:bg-slate-800/50 border-transparent focus:border-primary/50 h-12 rounded-xl transition-all"
            />
          </div>

          {error && (
            <div className="flex items-center gap-2 p-3 rounded-xl bg-destructive/10 text-destructive text-xs font-semibold animate-in slide-in-from-top-2">
              <AlertCircle size={14} />
              <span>{error}</span>
            </div>
          )}

          <Button 
            type="submit" 
            className="w-full h-12 mt-4 bg-primary hover:bg-primary/90 text-white font-bold rounded-xl shadow-lg shadow-primary/25 transition-all active:scale-[0.98]" 
            disabled={loading}
          >
            {loading ? (
              <div className="flex items-center gap-2">
                <div className="w-4 h-4 border-2 border-white/30 border-t-white rounded-full animate-spin" />
                <span>Đang xác thực...</span>
              </div>
            ) : 'Đăng nhập vào hệ thống'}
          </Button>
        </form>

        <div className="mt-8 pt-6 border-t border-slate-100 dark:border-slate-800 text-center">
            <p className="text-[10px] font-bold uppercase tracking-widest opacity-30">Medical Data Schema System v2.0</p>
        </div>
      </div>
    </div>
  );
}
