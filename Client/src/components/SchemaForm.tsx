import { Form, Input, Select, Checkbox, Button } from 'antd';
import { useEffect } from 'react';

const { TextArea } = Input;
const { Option } = Select;

export function GroupForm({ initialData = {}, onSubmit }: { initialData?: any, onSubmit: (data: any) => void }) {
  const [form] = Form.useForm();

  useEffect(() => {
    form.setFieldsValue({
      name: '',
      sqlTableName: '',
      cardinality: '1:1',
      description: '',
      ...initialData
    });
  }, [initialData, form]);

  return (
    <Form layout="vertical" form={form} onFinish={onSubmit}
      onValuesChange={(changedValues) => {
        if (changedValues.name && !initialData.id) { // Auto-generate slug for new groups
          const slug = changedValues.name.toLowerCase()
            .normalize('NFD')
            .replace(/[\u0300-\u036f]/g, '')
            .replace(/đ/g, 'd')
            .replace(/[^a-z0-9\s-]/g, '')
            .trim()
            .replace(/\s+/g, '_');
            
          const tierPrefix = initialData?.tierId ? `bnt${initialData.tierId}_` : 'bnt_';
          form.setFieldsValue({ sqlTableName: `${tierPrefix}${slug.substring(0, 50)}` });
        }
      }}
    >
      <Form.Item name="name" label="Tên nhóm (Hiển thị)" rules={[{ required: true, message: 'Vui lòng nhập tên nhóm' }]}>
        <Input placeholder="Ví dụ: Bệnh sử" />
      </Form.Item>
      
      <Form.Item name="sqlTableName" label="Tên bảng SQL" rules={[{ required: true, message: 'Vui lòng nhập tên bảng SQL' }]}>
        <Input placeholder="Ví dụ: bnt3_benh_su" />
      </Form.Item>

      <Form.Item name="cardinality" label="Quan hệ (Bản số)">
        <Select>
          <Option value="1:1">1:1 (Một - Một)</Option>
          <Option value="1:N">1:N (Một - Nhiều)</Option>
          <Option value="N:N">N:N (Nhiều - Nhiều)</Option>
        </Select>
      </Form.Item>

      <Form.Item name="description" label="Mô tả">
        <TextArea rows={2} placeholder="Mô tả nhóm dữ liệu..." />
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit">Lưu Nhóm</Button>
      </Form.Item>
    </Form>
  );
}

export function AttributeForm({ initialData = {}, onSubmit, parentGroupName, tierId }: { initialData?: any, onSubmit: (data: any) => void, parentGroupName?: string, tierId?: number }) {
  const [form] = Form.useForm();

  useEffect(() => {
    form.setFieldsValue({
      name: '',
      sqlColumnName: '',
      dataType: 'VARCHAR',
      cardinality: '1:1',
      isRequired: false,
      defaultValue: '',
      description: '',
      fkTarget: '',
      isHidden: false,
      hasPermission: false,
      scope: 'System',
      ...initialData
    });
  }, [initialData, form]);

  return (
    <Form layout="vertical" form={form} onFinish={onSubmit}
      onValuesChange={(changedValues) => {
        if (changedValues.name && !initialData.id) { // Auto-generate slug for new attributes
          const slug = changedValues.name.toLowerCase()
            .normalize('NFD')
            .replace(/[\u0300-\u036f]/g, '')
            .replace(/đ/g, 'd')
            .replace(/[^a-z0-9\s-]/g, '')
            .trim()
            .replace(/\s+/g, '_');
          
          let prefix = '';
          if (tierId && parentGroupName) {
            const groupSlug = parentGroupName.toLowerCase()
              .normalize('NFD')
              .replace(/[\u0300-\u036f]/g, '')
              .replace(/đ/g, 'd')
              .replace(/[^a-z0-9\s-]/g, '')
              .trim()
              .replace(/\s+/g, '_');
            prefix = `bnt${tierId}_${groupSlug}_`;
          }
          
          form.setFieldsValue({ sqlColumnName: `${prefix}${slug}`.substring(0, 100) });
        }
      }}
    >
      <Form.Item name="name" label="Tên thuộc tính (Hiển thị)" rules={[{ required: true, message: 'Vui lòng nhập tên thuộc tính' }]}>
        <Input placeholder="Ví dụ: Tên bệnh" />
      </Form.Item>
      
      <Form.Item name="sqlColumnName" label="Tên cột SQL" rules={[{ required: true, message: 'Vui lòng nhập tên cột SQL' }]}>
        <Input placeholder="Ví dụ: bnt3_benh_su_ten_benh" />
      </Form.Item>

      <Form.Item name="dataType" label="Kiểu dữ liệu SQL">
        <Select>
          <Option value="VARCHAR">VARCHAR (Văn bản ngắn)</Option>
          <Option value="TEXT">TEXT (Văn bản dài)</Option>
          <Option value="INT">INT (Số nguyên)</Option>
          <Option value="DECIMAL">DECIMAL (Số thập phân)</Option>
          <Option value="DATE">DATE (Ngày)</Option>
          <Option value="DATETIME">DATETIME (Ngày giờ)</Option>
          <Option value="BIT">BIT (Boolean / Checkbox)</Option>
          <Option value="JSON">JSON (Dữ liệu phức hợp)</Option>
          <Option value="ENUM">ENUM (Danh sách chọn)</Option>
          <Option value="FILE">FILE (Đường dẫn tệp)</Option>
          <Option value="REF">REF/FK (Khóa ngoại)</Option>
        </Select>
      </Form.Item>

      <Form.Item noStyle dependencies={['dataType']}>
        {({ getFieldValue }) => 
          getFieldValue('dataType') === 'REF' ? (
            <Form.Item name="fkTarget" label="Bảng mục tiêu tham chiếu (FK Target)" rules={[{ required: true }]}>
              <Input placeholder="Ví dụ: bnt5_he_co_quan(Id)" />
            </Form.Item>
          ) : null
        }
      </Form.Item>

      <Form.Item name="cardinality" label="Quan hệ (Với bảng chính)">
        <Select>
          <Option value="1:1">1:1 (Một - Một)</Option>
          <Option value="1:N">1:N (Một - Nhiều)</Option>
          <Option value="N:N">N:N (Nhiều - Nhiều)</Option>
        </Select>
      </Form.Item>

      <Form.Item name="isRequired" valuePropName="checked">
        <Checkbox>Bắt buộc nhập (NOT NULL)</Checkbox>
      </Form.Item>

      <Form.Item name="isHidden" valuePropName="checked">
        <Checkbox>Ẩn khỏi UI mặc định</Checkbox>
      </Form.Item>

      <Form.Item name="hasPermission" valuePropName="checked">
        <Checkbox>Được cấp quyền riêng</Checkbox>
      </Form.Item>

      <Form.Item name="scope" label="Phạm vi hiển thị">
        <Select>
          <Option value="System">Hệ thống (Toàn cục)</Option>
          <Option value="Admin">Chỉ Quản trị viên</Option>
          <Option value="User">Người dùng cuối</Option>
        </Select>
      </Form.Item>

      <Form.Item name="defaultValue" label="Giá trị mặc định">
        <Input placeholder="Ví dụ: 0, 'none'..." />
      </Form.Item>

      <Form.Item name="description" label="Ghi chú">
        <TextArea rows={2} placeholder="Mô tả ngắn gọn mục đích cột dữ liệu..." />
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit">Lưu Thuộc Tính</Button>
      </Form.Item>
    </Form>
  );
}
