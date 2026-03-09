import { useState } from 'react';
import { Card, Form, Input, Button, Alert, Typography } from 'antd';
import { DatabaseOutlined, UserOutlined, LockOutlined } from '@ant-design/icons';
import { useAuthStore } from '../store/authStore';
import { api } from '../lib/api';
import { useNavigate } from 'react-router-dom';

const { Title, Text } = Typography;

export default function Login() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const login = useAuthStore(state => state.login);
  const navigate = useNavigate();

  const handleLogin = async (values: { username: string; password: string }) => {
    setError('');
    setLoading(true);
    try {
      const { data } = await api.post('/auth/login', values);
      login(data.accessToken, data.refreshToken, values.username);
      navigate('/');
    } catch (err: any) {
      setError(err.response?.data?.message || 'Đăng nhập thất bại. Vui lòng thử lại.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{
      display: 'flex', alignItems: 'center', justifyContent: 'center',
      minHeight: '100vh', background: '#f0f2f5', padding: 16,
    }}>
      <Card
        style={{ width: 420, borderRadius: 24, border: '1px solid rgba(0,0,0,0.06)' }}
        styles={{ body: { padding: 40 } }}
      >
        <div style={{ textAlign: 'center', marginBottom: 40 }}>
          <div style={{
            width: 64, height: 64, borderRadius: 16, margin: '0 auto 16px',
            background: 'linear-gradient(135deg, #4f46e5, #3b82f6)',
            display: 'flex', alignItems: 'center', justifyContent: 'center',
            boxShadow: '0 8px 24px rgba(79,70,229,0.3)',
          }}>
            <DatabaseOutlined style={{ fontSize: 32, color: '#fff' }} />
          </div>
          <Title level={3} style={{ margin: 0 }}>S&H — Builder</Title>
          <Text type="secondary">Bắt đầu thiết kế cấu trúc dữ liệu của bạn</Text>
        </div>

        <Form onFinish={handleLogin} layout="vertical" size="large">
          <Form.Item
            label="Tên đăng nhập"
            name="username"
            rules={[{ required: true, message: 'Vui lòng nhập tên đăng nhập' }]}
          >
            <Input prefix={<UserOutlined />} placeholder="admin" />
          </Form.Item>

          <Form.Item
            label="Mật khẩu"
            name="password"
            rules={[{ required: true, message: 'Vui lòng nhập mật khẩu' }]}
          >
            <Input.Password prefix={<LockOutlined />} placeholder="••••••••" />
          </Form.Item>

          {error && (
            <Alert message={error} type="error" showIcon style={{ marginBottom: 16, borderRadius: 8 }} />
          )}

          <Form.Item>
            <Button type="primary" htmlType="submit" block loading={loading} size="large">
              {loading ? 'Đang xác thực...' : 'Đăng nhập vào hệ thống'}
            </Button>
          </Form.Item>
        </Form>

        <div style={{ textAlign: 'center', paddingTop: 16, borderTop: '1px solid rgba(0,0,0,0.06)' }}>
          <Text type="secondary" style={{ fontSize: 10, fontWeight: 600, textTransform: 'uppercase', letterSpacing: 1.5 }}>
            Medical Data Schema System v2.0
          </Text>
        </div>
      </Card>
    </div>
  );
}
