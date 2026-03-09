import { useState } from 'react';
import { Modal, Button, Space, Typography, Segmented, message } from 'antd';
import {
  CopyOutlined,
  CheckOutlined,
  FileTextOutlined,
  GlobalOutlined,
  InfoCircleOutlined,
} from '@ant-design/icons';
import type { Tier, Group } from '../hooks/useSchema';

const { Text } = Typography;

interface SqlPreviewModalProps {
  isOpen: boolean;
  onClose: () => void;
  tier?: Tier;
  allTiers?: Tier[];
}

export function SqlPreviewModal({ isOpen, onClose, tier, allTiers }: SqlPreviewModalProps) {
  const [copied, setCopied] = useState(false);
  const [mode, setMode] = useState<'single' | 'all'>(tier ? 'single' : 'all');

  if (!isOpen) return null;

  const generateSqlForTier = (t: Tier) => {
    let sql = `-- =============================================\n`;
    sql += `-- SQL Schema for Tier ${t.id}: ${t.name}\n`;
    sql += `-- Nature: ${t.nature}\n`;
    sql += `-- =============================================\n\n`;

    const recursivelyGenerateTables = (groups: Group[], parentGroup?: Group) => {
      let tierSql = '';
      groups.forEach(group => {
        const tableName = group.sqlTableName;
        tierSql += `CREATE TABLE [dbo].[${tableName}] (\n`;
        tierSql += `    [Id] INT IDENTITY(1,1) PRIMARY KEY,\n`;

        if (parentGroup) {
          tierSql += `    [${parentGroup.sqlTableName}_id] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[${parentGroup.sqlTableName}](Id),\n`;
        }

        const columnDefinitions = group.attributes.map(attr => {
          let line = `    [${attr.sqlColumnName}] `;
          const typeMapping: Record<string, string> = {
            VARCHAR: 'VARCHAR(255)', NVARCHAR: 'NVARCHAR(255)', TEXT: 'NVARCHAR(MAX)',
            INT: 'INT', DECIMAL: 'DECIMAL(18,4)', DATE: 'DATE', DATETIME: 'DATETIME2',
            BIT: 'BIT', JSON: 'NVARCHAR(MAX)', ENUM: 'NVARCHAR(100)',
          };

          if (attr.dataType === 'REF' || attr.dataType === 'FK') {
            if (attr.fkTarget) {
              const match = attr.fkTarget.match(/([a-zA-Z0-9_-]+)\((.*)\)/);
              line += match ? `INT FOREIGN KEY REFERENCES [dbo].[${match[1]}](${match[2]})` : `INT /* Invalid FK: ${attr.fkTarget} */`;
            } else {
              line += `INT /* Missing FK Target */`;
            }
          } else {
            line += typeMapping[attr.dataType] || attr.dataType || 'NVARCHAR(MAX)';
          }

          if (attr.isRequired) line += ' NOT NULL';
          if (attr.defaultValue) {
            const def = attr.defaultValue.startsWith("'") || !isNaN(Number(attr.defaultValue)) ? attr.defaultValue : `'${attr.defaultValue}'`;
            line += ` DEFAULT ${def}`;
          }
          return line;
        });

        if (columnDefinitions.length > 0) {
          tierSql += columnDefinitions.join(',\n') + '\n';
        }
        tierSql += `);\nGO\n\n`;

        if (group.subGroups && group.subGroups.length > 0) {
          tierSql += recursivelyGenerateTables(group.subGroups, group);
        }
      });
      return tierSql;
    };

    sql += recursivelyGenerateTables(t.groups || []);
    return sql;
  };

  const generateFullSql = () => {
    let sql = `-- S&H PATIENT DATA SCHEMA - FULL EXPORT\n`;
    sql += `-- Generated: ${new Date().toLocaleString()}\n`;
    sql += `-- =============================================\n\n`;

    sql += `IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patient]') AND type in (N'U'))\nBEGIN\n`;
    sql += `CREATE TABLE [dbo].[Patient] (\n    [Id] INT IDENTITY(1,1) PRIMARY KEY,\n    [PatientCode] NVARCHAR(50) NOT NULL UNIQUE,\n    [CreatedAt] DATETIME2 DEFAULT GETDATE()\n);\nEND\nGO\n\n`;

    if (mode === 'all' && allTiers) {
      allTiers.sort((a, b) => a.id - b.id).forEach(t => { sql += generateSqlForTier(t); });
    } else if (tier) {
      sql += generateSqlForTier(tier);
    }
    return sql;
  };

  const fullSql = generateFullSql();

  const handleCopy = () => {
    navigator.clipboard.writeText(fullSql);
    setCopied(true);
    message.success('Đã sao chép SQL vào clipboard!');
    setTimeout(() => setCopied(false), 2000);
  };

  const getLineStyle = (line: string): React.CSSProperties => {
    const trimmed = line.trim();
    if (trimmed.startsWith('--')) return { color: '#6ee7b7', fontStyle: 'italic' };
    if (line.includes('CREATE TABLE')) return { color: '#f472b6', fontWeight: 700 };
    if (trimmed === 'GO') return { color: '#fb923c', fontWeight: 600 };
    if (line.includes('FOREIGN KEY')) return { color: '#60a5fa', fontWeight: 500 };
    return { color: '#cbd5e1' };
  };

  return (
    <Modal
      open={isOpen}
      onCancel={onClose}
      width={1100}
      footer={
        <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <Space>
            <InfoCircleOutlined style={{ color: '#4f46e5' }} />
            <Text type="secondary" style={{ fontSize: 11 }}>Compatible with MS SQL Server / Azure SQL</Text>
          </Space>
          <Space>
            <Button onClick={onClose}>Đóng</Button>
          </Space>
        </div>
      }
      title={
        <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <Space>
            <FileTextOutlined style={{ color: '#4f46e5', fontSize: 20 }} />
            <span style={{ fontWeight: 700, fontSize: 16 }}>SQL Schema Generator</span>
          </Space>
          <Space>
            <Segmented
              value={mode}
              onChange={(val) => setMode(val as 'single' | 'all')}
              options={[
                { label: `Tier ${tier?.id || '?'} Only`, value: 'single' },
                { label: <Space size={4}><GlobalOutlined /> Full Schema</Space>, value: 'all' },
              ]}
              size="small"
            />
            <Button
              type="primary"
              icon={copied ? <CheckOutlined /> : <CopyOutlined />}
              onClick={handleCopy}
            >
              {copied ? 'Đã chép' : 'Sao chép'}
            </Button>
          </Space>
        </div>
      }
      styles={{
        body: { padding: 0, maxHeight: 'calc(80vh - 120px)', overflow: 'auto' },
        header: { padding: '16px 24px', borderBottom: '1px solid rgba(255,255,255,0.06)' },
      }}
      destroyOnClose
    >
      <div className="custom-scrollbar" style={{ background: '#1e1e2e', padding: '24px 0', overflow: 'auto', maxHeight: 'calc(80vh - 160px)' }}>
        <pre style={{ margin: 0, fontSize: 13, fontFamily: "'Fira Code', 'Cascadia Code', monospace", lineHeight: 1.8 }}>
          {fullSql.split('\n').map((line, i) => (
            <div key={i} className="sql-line" style={{ display: 'flex', gap: 24, padding: '0 24px', borderRadius: 4 }}>
              <span style={{ width: 40, textAlign: 'right', color: 'rgba(255,255,255,0.2)', userSelect: 'none', fontWeight: 600 }}>{i + 1}</span>
              <span style={getLineStyle(line)}>{line}</span>
            </div>
          ))}
        </pre>
      </div>
    </Modal>
  );
}
