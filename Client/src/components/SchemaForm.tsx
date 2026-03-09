import { useEffect } from 'react';
import { Form, Input, Select, Checkbox, Button, Alert, Row, Col, Divider } from 'antd';
import {
  SaveOutlined,
  WarningOutlined,
} from '@ant-design/icons';

const CoreWarning = () => (
  <Alert
    message="Cảnh báo: Core System Field"
    description="Đây là thành phần thuộc Schema gốc của hệ thống S&H. Việc thay đổi có thể gây lỗi đồng bộ dữ liệu nghiêm trọng. Vui lòng chỉ chỉnh sửa khi thực sự cần thiết."
    type="error"
    showIcon
    icon={<WarningOutlined />}
    style={{ marginBottom: 24, borderRadius: 12 }}
  />
);

export function GroupForm({ initialData = {}, onSubmit }: { initialData?: any; onSubmit: (data: any) => void }) {
  const [form] = Form.useForm();
  const isCore = !!initialData.isCore;

  useEffect(() => {
    form.setFieldsValue({ ...initialData });
  }, [initialData, form]);

  const onNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!initialData.id) {
      const slug = e.target.value
        .toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9\s-]/g, '')
        .trim()
        .replace(/\s+/g, '_');
      const tierId = initialData.tierId || 1;
      form.setFieldsValue({
        sqlTableName: `bnt${tierId}_${slug}`.substring(0, 50),
        tableNameFull: slug,
      });
    }
  };

  const handleFinish = (values: any) => {
    if (isCore && !confirm('Cảnh báo: Đây là core field từ schema gốc! Bạn vẫn muốn tiếp tục?')) return;
    onSubmit(values);
  };

  return (
    <Form form={form} layout="vertical" onFinish={handleFinish} initialValues={initialData}>
      {isCore && <CoreWarning />}

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Tên hiển thị" name="name" rules={[{ required: true }]}>
            <Input placeholder="ví dụ: Thông tin hành chính" disabled={isCore} onChange={onNameChange} />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Tên bảng SQL (Short)" name="sqlTableName">
            <Input placeholder="bntX_ten_bang" disabled={isCore} />
          </Form.Item>
        </Col>
      </Row>

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Tên bảng đầy đủ" name="tableNameFull">
            <Input placeholder="nhomduocly" disabled={isCore} />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Bản số (Cardinality)" name="cardinality">
            <Select disabled={isCore} options={[
              { label: '1:1 (Một - Một)', value: '1:1' },
              { label: '1:N (Một - Nhiều)', value: '1:N' },
              { label: 'N:N (Nhiều - Nhiều)', value: 'N:N' },
            ]} />
          </Form.Item>
        </Col>
      </Row>

      <Form.Item label="Ghi chú & Mô tả" name="description">
        <Input.TextArea rows={4} placeholder="Nhập mô tả chi tiết về nhóm dữ liệu này..." />
      </Form.Item>

      <Divider />

      <Form.Item>
        <Button
          type="primary"
          htmlType="submit"
          icon={<SaveOutlined />}
          block
          size="large"
          danger={isCore}
        >
          {isCore ? 'Ghi đè cấu trúc lõi' : 'Lưu thông tin nhóm'}
        </Button>
      </Form.Item>
    </Form>
  );
}

export function AttributeForm({ initialData = {}, onSubmit, parentGroupName, tierId }: { initialData?: any; onSubmit: (data: any) => void; parentGroupName?: string; tierId?: number }) {
  const [form] = Form.useForm();
  const isCore = !!initialData.isCore;

  useEffect(() => {
    form.setFieldsValue({ ...initialData });
  }, [initialData, form]);

  const onNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!initialData.id && parentGroupName && tierId) {
      const slug = e.target.value
        .toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9\s-]/g, '')
        .trim()
        .replace(/\s+/g, '_');
      const groupSlug = parentGroupName
        .toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9\s-]/g, '')
        .trim()
        .replace(/\s+/g, '_');
      form.setFieldsValue({
        sqlColumnName: `bnt${tierId}_${groupSlug}_${slug}`.substring(0, 100),
      });
    }
  };

  const handleFinish = (values: any) => {
    if (isCore && !confirm('Cảnh báo: Đây là core field từ schema gốc! Bạn vẫn muốn tiếp tục?')) return;
    onSubmit(values);
  };

  const dataType = Form.useWatch('dataType', form);

  return (
    <Form form={form} layout="vertical" onFinish={handleFinish} initialValues={initialData}>
      {isCore && <CoreWarning />}

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Tên thuộc tính" name="name" rules={[{ required: true }]}>
            <Input placeholder="ví dụ: Họ và tên" disabled={isCore} onChange={onNameChange} />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Tên cột SQL" name="sqlColumnName">
            <Input placeholder="bntX_nhom_ten" disabled={isCore} />
          </Form.Item>
        </Col>
      </Row>

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Kiểu dữ liệu" name="dataType">
            <Select disabled={isCore} options={[
              { label: 'VARCHAR', value: 'VARCHAR' },
              { label: 'NVARCHAR', value: 'NVARCHAR' },
              { label: 'INT', value: 'INT' },
              { label: 'TEXT', value: 'TEXT' },
              { label: 'DATE', value: 'DATE' },
              { label: 'DATETIME', value: 'DATETIME' },
              { label: 'BIT', value: 'BIT' },
              { label: 'DECIMAL', value: 'DECIMAL' },
              { label: 'REF/FK', value: 'REF' },
              { label: 'JSON', value: 'JSON' },
            ]} />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Bản số" name="cardinality">
            <Select disabled={isCore} options={[
              { label: '1:1', value: '1:1' },
              { label: '1:N', value: '1:N' },
            ]} />
          </Form.Item>
        </Col>
      </Row>

      {dataType === 'REF' && (
        <Form.Item label="Bảng tham chiếu (Target)" name="fkTarget">
          <Input placeholder="bnt5_hecoquan(Id)" disabled={isCore} />
        </Form.Item>
      )}

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item name="isRequired" valuePropName="checked">
            <Checkbox disabled={isCore}>Bắt buộc nhập (NOT NULL)</Checkbox>
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item name="isCore" valuePropName="checked">
            <Checkbox disabled={isCore}>Trường dữ liệu lõi (Core)</Checkbox>
          </Form.Item>
        </Col>
      </Row>

      <Form.Item label="Giá trị mặc định" name="defaultValue">
        <Input placeholder="NULL / 'DEFAULT_VAL' / GETDATE()" disabled={isCore} />
      </Form.Item>

      <Divider />

      <Form.Item>
        <Button
          type="primary"
          htmlType="submit"
          icon={<SaveOutlined />}
          block
          size="large"
          danger={isCore}
        >
          {isCore ? 'Ghi đè cấu trúc lõi' : 'Lưu thuộc tính'}
        </Button>
      </Form.Item>
    </Form>
  );
}
