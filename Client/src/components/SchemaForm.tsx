import { useEffect } from 'react';
import { Form, Input, Select, Checkbox, Button, Row, Col, Divider } from 'antd';
import {
  SaveOutlined,
} from '@ant-design/icons';

export function GroupForm({ initialData = {}, onSubmit }: { initialData?: any; onSubmit: (data: any) => void }) {
  const [form] = Form.useForm();

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
        .replace(/[^a-z0-9]/g, '');
      const tierId = initialData.tierId || 1;
      form.setFieldsValue({
        sqlTableName: `bnt${tierId}_${slug}`.substring(0, 50),
      });
    }
  };

  return (
    <Form form={form} layout="vertical" onFinish={onSubmit} initialValues={initialData}>
      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Tên hiển thị" name="name" rules={[{ required: true }]}>
            <Input placeholder="ví dụ: Thông tin hành chính" onChange={onNameChange} />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Tên bảng SQL" name="sqlTableName">
            <Input placeholder="bntX_ten_bang" />
          </Form.Item>
        </Col>
      </Row>

      <Form.Item label="Quan hệ" name="cardinality">
        <Select options={[
          { label: '1:1 (Một - Một)', value: '1:1' },
          { label: '1:N (Một - Nhiều)', value: '1:N' },
          { label: 'N:N (Nhiều - Nhiều)', value: 'N:N' },
        ]} />
      </Form.Item>

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
        >
          Lưu thông tin nhóm
        </Button>
      </Form.Item>
    </Form>
  );
}

export function AttributeForm({ initialData = {}, onSubmit, parentGroupName, tierId }: { initialData?: any; onSubmit: (data: any) => void; parentGroupName?: string; tierId?: number }) {
  const [form] = Form.useForm();

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
        .replace(/[^a-z0-9]/g, '');
      const groupSlug = parentGroupName
        .toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9]/g, '');
      form.setFieldsValue({
        sqlColumnName: `bnt${tierId}_${groupSlug}_${slug}`.substring(0, 100),
      });
    }
  };

  const dataType = Form.useWatch('dataType', form);

  return (
    <Form form={form} layout="vertical" onFinish={onSubmit} initialValues={initialData}>
      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Tên thuộc tính" name="name" rules={[{ required: true }]}>
            <Input placeholder="ví dụ: Họ và tên" onChange={onNameChange} />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Tên cột SQL" name="sqlColumnName">
            <Input placeholder="bntX_nhom_ten" />
          </Form.Item>
        </Col>
      </Row>

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item label="Kiểu dữ liệu" name="dataType">
            <Select options={[
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
          <Form.Item label="Quan hệ" name="cardinality">
            <Select options={[
              { label: '1:1', value: '1:1' },
              { label: '1:N', value: '1:N' },
            ]} />
          </Form.Item>
        </Col>
      </Row>

      {dataType === 'REF' && (
        <Form.Item label="Bảng tham chiếu (Target)" name="fkTarget">
          <Input placeholder="bnt5_hecoquan(Id)" />
        </Form.Item>
      )}

      <Row gutter={16}>
        <Col span={12}>
          <Form.Item name="isRequired" valuePropName="checked">
            <Checkbox>Bắt buộc nhập (NOT NULL)</Checkbox>
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item name="isCore" valuePropName="checked">
            <Checkbox>Trường dữ liệu lõi (Core)</Checkbox>
          </Form.Item>
        </Col>
      </Row>

      <Form.Item label="Giá trị mặc định" name="defaultValue">
        <Input placeholder="NULL / 'DEFAULT_VAL' / GETDATE()" />
      </Form.Item>

      <Divider />

      <Form.Item>
        <Button
          type="primary"
          htmlType="submit"
          icon={<SaveOutlined />}
          block
          size="large"
        >
          Lưu thông tin thuộc tính
        </Button>
      </Form.Item>
    </Form>
  );
}
