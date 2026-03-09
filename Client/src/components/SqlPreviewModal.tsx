import { Modal, Typography } from 'antd';
import type { Tier, Group, SchemaAttribute } from '../hooks/useSchema';

const { Text } = Typography;

interface SqlPreviewModalProps {
  isOpen: boolean;
  onClose: () => void;
  tier?: Tier;
}

export function SqlPreviewModal({ isOpen, onClose, tier }: SqlPreviewModalProps) {
  
  const generateSql = () => {
    if (!tier) return '-- No tier selected';

    let sql = `-- SQL Schema for Tier ${tier.id}: ${tier.name}\n`;
    sql += `-- Generated automatically by S&H Schema Builder\n\n`;

    const recursivelyGenerateTables = (groups: Group[], parentGroup?: Group) => {
      groups.forEach(group => {
        const tableName = group.sqlTableName;
        
        sql += `CREATE TABLE [dbo].[${tableName}] (\n`;
        sql += `    [Id] INT IDENTITY(1,1) PRIMARY KEY,\n`;
        
        // Setup references
        sql += `    [PatientId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Patient](Id),\n`;
        if (parentGroup) {
          sql += `    [${parentGroup.sqlTableName}Id] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[${parentGroup.sqlTableName}](Id),\n`;
        }
        
        // Attributes
        const columns = group.attributes.map(attr => {
          let line = `    [${attr.sqlColumnName}] `;
          
          if (attr.dataType === 'VARCHAR') line += `NVARCHAR(255)`;
          else if (attr.dataType === 'TEXT') line += `NVARCHAR(MAX)`;
          else if (attr.dataType === 'INT') line += `INT`;
          else if (attr.dataType === 'DECIMAL') line += `DECIMAL(18,2)`;
          else if (attr.dataType === 'DATE') line += `DATE`;
          else if (attr.dataType === 'DATETIME') line += `DATETIME2`;
          else if (attr.dataType === 'BIT') line += `BIT`;
          else if (attr.dataType === 'JSON') line += `NVARCHAR(MAX)`;
          else if (attr.dataType === 'ENUM') line += `NVARCHAR(100)`;
          else if (attr.dataType === 'FILE') line += `NVARCHAR(MAX)`;
          else if (attr.dataType === 'REF' && attr.fkTarget) {
             const targetParts = attr.fkTarget.match(/([a-zA-Z0-9_-]+)\((.*)\)/);
             if (targetParts) {
                 line += `INT FOREIGN KEY REFERENCES [dbo].[${targetParts[1]}](${targetParts[2]})`;
             } else {
                 line += `INT /* Invalid FK: ${attr.fkTarget} */`;
             }
          }
          else line += `NVARCHAR(Max)`;

          if (attr.isRequired) line += ` NOT NULL`;
          if (attr.defaultValue) line += ` DEFAULT ${attr.defaultValue}`;
          
          return line;
        });

        if (columns.length > 0) {
           sql += columns.join(',\n') + '\n';
        }
        
        sql += `);\nGO\n\n`;

        if (group.subGroups && group.subGroups.length > 0) {
           recursivelyGenerateTables(group.subGroups, group);
        }
      });
    };

    recursivelyGenerateTables(tier.groups);
    return sql;
  };

  return (
    <Modal
      title={`SQL Schema Preview - Tier ${tier?.id}`}
      open={isOpen}
      onCancel={onClose}
      width={800}
      footer={null}
      style={{ top: 20 }}
    >
      <div style={{ maxHeight: '70vh', overflowY: 'auto', backgroundColor: '#f5f5f5', padding: 16, borderRadius: 8 }}>
        <pre style={{ margin: 0, fontFamily: 'Consolas, monospace', fontSize: 13, whiteSpace: 'pre-wrap' }}>
          {generateSql()}
        </pre>
      </div>
    </Modal>
  );
}
