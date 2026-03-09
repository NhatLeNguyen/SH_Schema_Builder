import { useEffect, useState } from 'react';
import { 
  Save, 
  Hash,
  Type,
  Layers,
  Link,
  Database,
  AlertTriangle,
  Info,
  BadgeCheck,
  ShieldAlert,
  RefreshCw
} from 'lucide-react';
import { cn } from '../lib/utils';

const InputField = ({ label, value, onChange, placeholder, disabled, icon: Icon, type = "text" }: any) => (
  <div className="space-y-2">
    <label className="text-[11px] font-black text-muted-foreground uppercase tracking-[0.1em] flex items-center gap-2 px-1">
      {Icon && <Icon size={12} className="text-primary/60" />}
      {label}
    </label>
    <div className="relative group/input">
      <input
        type={type}
        value={value || ''}
        onChange={(e) => onChange(e.target.value)}
        placeholder={placeholder}
        disabled={disabled}
        className={cn(
          "w-full bg-accent/30 border border-border/40 rounded-2xl px-4 py-3 text-sm transition-all focus:ring-4 focus:ring-primary/10 focus:border-primary outline-none hover:border-border/80 font-medium",
          disabled && "opacity-50 cursor-not-allowed bg-muted"
        )}
      />
      <div className="absolute inset-0 rounded-2xl bg-primary/5 opacity-0 group-hover/input:opacity-100 transition-opacity pointer-events-none" />
    </div>
  </div>
);

const SelectField = ({ label, value, onChange, options, icon: Icon, disabled }: any) => (
  <div className="space-y-2">
    <label className="text-[11px] font-black text-muted-foreground uppercase tracking-[0.1em] flex items-center gap-2 px-1">
      {Icon && <Icon size={12} className="text-primary/60" />}
      {label}
    </label>
    <div className="relative group/select">
      <select
        value={value || ''}
        onChange={(e) => onChange(e.target.value)}
        disabled={disabled}
        className={cn(
          "w-full bg-accent/30 border border-border/40 rounded-2xl px-4 py-3 text-sm transition-all focus:ring-4 focus:ring-primary/10 focus:border-primary outline-none appearance-none font-medium hover:border-border/80",
          disabled && "opacity-50 cursor-not-allowed bg-muted"
        )}
      >
        {options.map((opt: any) => (
          <option key={opt.value} value={opt.value} className="bg-background">{opt.label}</option>
        ))}
      </select>
      <div className="absolute right-4 top-1/2 -translate-y-1/2 pointer-events-none opacity-40">
        <Hash size={14} />
      </div>
      <div className="absolute inset-0 rounded-2xl bg-primary/5 opacity-0 group-hover/select:opacity-100 transition-opacity pointer-events-none" />
    </div>
  </div>
);

const CheckboxField = ({ label, checked, onChange, description, disabled }: any) => (
  <div 
    className={cn(
      "flex items-start gap-4 p-4 rounded-3xl border-2 transition-all cursor-pointer group/check",
      checked ? "bg-primary/[0.03] border-primary/20" : "bg-accent/20 border-transparent hover:border-border/60",
      disabled && "opacity-50 cursor-not-allowed pointer-events-none"
    )} 
    onClick={() => !disabled && onChange(!checked)}
  >
    <div className={cn(
      "shrink-0 w-6 h-6 rounded-xl border-2 transition-all flex items-center justify-center",
      checked ? "bg-primary border-primary text-white shadow-lg shadow-primary/20 scale-110" : "border-border/60 bg-background"
    )}>
      {checked && <BadgeCheck size={14} strokeWidth={3} className="animate-in zoom-in-50 duration-300" />}
    </div>
    <div className="flex flex-col gap-0.5">
      <span className={cn("text-sm font-bold transition-colors", checked ? "text-primary" : "text-foreground")}>{label}</span>
      {description && <span className="text-[11px] text-muted-foreground font-medium opacity-70 leading-relaxed">{description}</span>}
    </div>
  </div>
);

const CoreWarning = () => (
   <div className="mb-8 p-6 rounded-[2rem] bg-destructive/5 border-2 border-destructive/20 animate-in fade-in slide-in-from-top-4 duration-500 overflow-hidden relative group">
      <div className="absolute top-[-20px] right-[-20px] opacity-10 group-hover:scale-110 transition-transform duration-1000">
         <ShieldAlert size={120} />
      </div>
      <div className="flex items-start gap-5 relative z-10">
        <div className="p-3 bg-destructive/10 text-destructive rounded-2xl shrink-0">
          <AlertTriangle size={24} strokeWidth={2.5} />
        </div>
        <div>
          <h4 className="text-sm font-black text-destructive uppercase tracking-widest mb-1">Cảnh báo: Core System Field</h4>
          <p className="text-xs text-destructive/80 font-bold leading-relaxed">
            Đây là thành phần thuộc Schema gốc của hệ thống S&H. Việc thay đổi có thể gây lỗi đồng bộ dữ liệu nghiêm trọng. 
            <span className="block mt-1 opacity-60">Vui lòng chỉ chỉnh sửa khi thực sự cần thiết.</span>
          </p>
        </div>
      </div>
   </div>
);

export function GroupForm({ initialData = {}, onSubmit }: { initialData?: any, onSubmit: (data: any) => void }) {
  const [formData, setFormData] = useState(initialData);

  useEffect(() => {
    setFormData({ ...initialData });
  }, [initialData]);

  const handleChange = (name: string, value: any) => {
    const nextData = { ...formData, [name]: value };
    
    // Auto-generate SQL name for new groups
    if (name === 'name' && !initialData.id) {
      const slug = value.toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9\s-]/g, '')
        .trim()
        .replace(/\s+/g, '_');
      
      const tierId = initialData.tierId || 1;
      nextData.sqlTableName = `bnt${tierId}_${slug}`.substring(0, 50);
      nextData.tableNameFull = slug;
    }
    
    setFormData(nextData);
  };

  const isCore = !!formData.isCore;

  return (
    <div className="space-y-8 animate-in fade-in duration-700">
      {isCore && <CoreWarning />}

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        <InputField 
          label="Tên hiển thị" 
          value={formData.name} 
          onChange={(v: string) => handleChange('name', v)} 
          placeholder="ví dụ: Thông tin hành chính"
          icon={Layers}
          disabled={isCore}
        />
        
        <InputField 
          label="Tên bảng SQL (Short)" 
          value={formData.sqlTableName} 
          onChange={(v: string) => handleChange('sqlTableName', v)} 
          placeholder="bntX_ten_bang"
          icon={Database}
          disabled={isCore}
        />
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        <InputField 
          label="Tên bảng đầy đủ" 
          value={formData.tableNameFull} 
          onChange={(v: string) => handleChange('tableNameFull', v)} 
          placeholder="nhomduocly"
          icon={Type}
          disabled={isCore}
        />

        <SelectField 
          label="Bản số (Cardinality)" 
          value={formData.cardinality} 
          onChange={(v: string) => handleChange('cardinality', v)}
          options={[
            { label: '1:1 (Một - Một)', value: '1:1' },
            { label: '1:N (Một - Nhiều)', value: '1:N' },
            { label: 'N:N (Nhiều - Nhiều)', value: 'N:N' }
          ]}
          icon={Hash}
          disabled={isCore}
        />
      </div>

      <div className="space-y-2">
        <label className="text-[11px] font-black text-muted-foreground uppercase tracking-[0.1em] flex items-center gap-2 px-1">
          <Info size={12} className="text-primary/60" />
          Ghi chú & Mô tả
        </label>
        <textarea
          value={formData.description || ''}
          onChange={(e) => handleChange('description', e.target.value)}
          rows={4}
          className="w-full bg-accent/30 border border-border/40 rounded-[2rem] px-5 py-4 text-sm transition-all focus:ring-4 focus:ring-primary/10 focus:border-primary outline-none hover:border-border/80 font-medium resize-none overflow-hidden"
          placeholder="Nhập mô tả chi tiết về nhóm dữ liệu này..."
        />
      </div>

      <div className="pt-4">
        <button 
          onClick={() => {
            if (isCore && !confirm('Cảnh báo: Đây là core field từ schema gốc! Bạn vẫn muốn tiếp tục?')) return;
            onSubmit(formData);
          }}
          className={cn(
            "w-full text-white font-black py-4 rounded-[2rem] shadow-2xl transition-all flex items-center justify-center gap-3 uppercase tracking-widest text-sm active:scale-95",
            isCore 
              ? "bg-destructive shadow-destructive/20 hover:bg-destructive/90" 
              : "bg-primary shadow-primary/20 hover:bg-primary/90 hover:scale-[1.02]"
          )}
        >
          <Save size={20} strokeWidth={2.5} />
          {isCore ? 'Ghi đè cấu trúc lõi' : 'Lưu thông tin nhóm'}
        </button>
      </div>
    </div>
  );
}

export function AttributeForm({ initialData = {}, onSubmit, parentGroupName, tierId }: { initialData?: any, onSubmit: (data: any) => void, parentGroupName?: string, tierId?: number }) {
  const [formData, setFormData] = useState(initialData);

  useEffect(() => {
    setFormData({ ...initialData });
  }, [initialData]);

  const handleChange = (name: string, value: any) => {
    const nextData = { ...formData, [name]: value };

    if (name === 'name' && !initialData.id && parentGroupName && tierId) {
      const slug = value.toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9\s-]/g, '')
        .trim()
        .replace(/\s+/g, '_');
      
      const groupSlug = parentGroupName.toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/[^a-z0-9\s-]/g, '')
        .trim()
        .replace(/\s+/g, '_');

      nextData.sqlColumnName = `bnt${tierId}_${groupSlug}_${slug}`.substring(0, 100);
    }

    setFormData(nextData);
  };

  const isCore = !!formData.isCore;

  return (
    <div className="space-y-8 animate-in fade-in duration-700">
      {isCore && <CoreWarning />}

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        <InputField 
          label="Tên thuộc tính" 
          value={formData.name} 
          onChange={(v: string) => handleChange('name', v)} 
          placeholder="ví dụ: Họ và tên"
          icon={Type}
          disabled={isCore}
        />

        <InputField 
          label="Tên cột SQL" 
          value={formData.sqlColumnName} 
          onChange={(v: string) => handleChange('sqlColumnName', v)} 
          placeholder="bntX_nhom_ten"
          icon={Database}
          disabled={isCore}
        />
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        <SelectField 
          label="Kiểu dữ liệu" 
          value={formData.dataType} 
          onChange={(v: string) => handleChange('dataType', v)}
          options={[
            { label: 'VARCHAR', value: 'VARCHAR' },
            { label: 'INT', value: 'INT' },
            { label: 'TEXT', value: 'TEXT' },
            { label: 'DATE', value: 'DATE' },
            { label: 'DATETIME', value: 'DATETIME' },
            { label: 'BIT', value: 'BIT' },
            { label: 'DECIMAL', value: 'DECIMAL' },
            { label: 'REF/FK', value: 'REF' },
            { label: 'JSON', value: 'JSON' }
          ]}
          icon={Layers}
          disabled={isCore}
        />
        <SelectField 
          label="Bản số" 
          value={formData.cardinality} 
          onChange={(v: string) => handleChange('cardinality', v)}
          options={[
            { label: '1:1', value: '1:1' },
            { label: '1:N', value: '1:N' }
          ]}
          icon={Hash}
          disabled={isCore}
        />
      </div>

      {formData.dataType === 'REF' && (
        <InputField 
          label="Bảng tham chiếu (Target)" 
          value={formData.fkTarget} 
          onChange={(v: string) => handleChange('fkTarget', v)} 
          placeholder="bnt5_hecoquan(Id)"
          icon={Link}
          disabled={isCore}
        />
      )}

      <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
        <CheckboxField 
          label="Bắt buộc nhập" 
          description="Ràng buộc NOT NULL"
          checked={formData.isRequired} 
          onChange={(v: boolean) => handleChange('isRequired', v)} 
          disabled={isCore}
        />
        <CheckboxField 
          label="Trường dữ liệu lõi" 
          description="Hệ thống mặc định"
          checked={formData.isCore} 
          onChange={(v: boolean) => handleChange('isCore', v)} 
          disabled={isCore}
        />
      </div>

      <div className="grid grid-cols-1 gap-6">
        <InputField 
          label="Giá trị mặc định" 
          value={formData.defaultValue} 
          onChange={(v: string) => handleChange('defaultValue', v)} 
          placeholder="NULL / 'DEFAULT_VAL' / GETDATE()"
          icon={RefreshCw}
          disabled={isCore}
        />
      </div>

      <div className="pt-4">
        <button 
          onClick={() => {
            if (isCore && !confirm('Cảnh báo: Đây là core field từ schema gốc! Bạn vẫn muốn tiếp tục?')) return;
            onSubmit(formData);
          }}
          className={cn(
            "w-full text-white font-black py-4 rounded-[2rem] shadow-2xl transition-all flex items-center justify-center gap-3 uppercase tracking-widest text-sm active:scale-95",
            isCore 
              ? "bg-destructive shadow-destructive/20 hover:bg-destructive/90" 
              : "bg-primary shadow-primary/20 hover:bg-primary/90 hover:scale-[1.02]"
          )}
        >
          <Save size={20} strokeWidth={2.5} />
          {isCore ? 'Ghi đè cấu trúc lõi' : 'Lưu thuộc tính'}
        </button>
      </div>
    </div>
  );
}
