import React from 'react';
import { X, Copy, Check, FileCode, Globe, Info } from 'lucide-react';
import { cn } from '../lib/utils';
import type { Tier, Group } from '../hooks/useSchema';

interface SqlPreviewModalProps {
  isOpen: boolean;
  onClose: () => void;
  tier?: Tier;
  allTiers?: Tier[];
}

export function SqlPreviewModal({ isOpen, onClose, tier, allTiers }: SqlPreviewModalProps) {
  const [copied, setCopied] = React.useState(false);
  const [mode, setMode] = React.useState<'single' | 'all'>(tier ? 'single' : 'all');

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
        
        // Add foreign key to parent if exists
        if (parentGroup) {
          tierSql += `    [${parentGroup.sqlTableName}_id] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[${parentGroup.sqlTableName}](Id),\n`;
        }
        
        const columnDefinitions = group.attributes.map(attr => {
          let line = `    [${attr.sqlColumnName}] `;
          
          const typeMapping: Record<string, string> = {
            'VARCHAR': 'VARCHAR(255)',
            'NVARCHAR': 'NVARCHAR(255)',
            'TEXT': 'NVARCHAR(MAX)',
            'INT': 'INT',
            'DECIMAL': 'DECIMAL(18,4)',
            'DATE': 'DATE',
            'DATETIME': 'DATETIME2',
            'BIT': 'BIT',
            'JSON': 'NVARCHAR(MAX)',
            'ENUM': 'NVARCHAR(100)',
            'FILE': 'NVARCHAR(MAX)',
          };

          let finalType = typeMapping[attr.dataType] || attr.dataType || 'NVARCHAR(MAX)';
          
          if (attr.dataType === 'REF' || attr.dataType === 'FK') {
            if (attr.fkTarget) {
              const match = attr.fkTarget.match(/([a-zA-Z0-9_-]+)\((.*)\)/);
              line += match ? `INT FOREIGN KEY REFERENCES [dbo].[${match[1]}](${match[2]})` : `INT /* Invalid FK: ${attr.fkTarget} */`;
            } else {
              line += `INT /* Missing FK Target */`;
            }
          } else {
            line += finalType;
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

    sql += `IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patient]') AND type in (N'U'))\n`;
    sql += `BEGIN\n`;
    sql += `CREATE TABLE [dbo].[Patient] (\n`;
    sql += `    [Id] INT IDENTITY(1,1) PRIMARY KEY,\n`;
    sql += `    [PatientCode] NVARCHAR(50) NOT NULL UNIQUE,\n`;
    sql += `    [CreatedAt] DATETIME2 DEFAULT GETDATE()\n`;
    sql += `);\n`;
    sql += `END\nGO\n\n`;

    if (mode === 'all' && allTiers) {
      allTiers.sort((a, b) => a.id - b.id).forEach(t => {
        sql += generateSqlForTier(t);
      });
    } else if (tier) {
      sql += generateSqlForTier(tier);
    }

    return sql;
  };

  const fullSql = generateFullSql();

  const handleCopy = () => {
    navigator.clipboard.writeText(fullSql);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000);
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/70 backdrop-blur-md animate-in fade-in duration-500">
      <div className="bg-background border border-border/60 rounded-[2.5rem] shadow-2xl w-full max-w-5xl max-h-[90vh] flex flex-col overflow-hidden animate-in zoom-in-95 duration-500">
        
        <div className="p-6 border-b border-border/40 flex items-center justify-between bg-card/20 backdrop-blur-xl">
          <div className="flex items-center gap-4">
            <div className="w-12 h-12 rounded-2xl bg-primary shadow-xl shadow-primary/20 flex items-center justify-center text-white">
              <FileCode size={24} strokeWidth={2.5} />
            </div>
            <div>
              <h3 className="text-xl font-black tracking-tighter">SQL Schema Generator</h3>
              <div className="flex items-center gap-3 mt-1">
                 <button 
                  onClick={() => setMode('single')}
                  className={cn(
                    "text-[10px] font-black uppercase tracking-widest px-2 py-0.5 rounded-full transition-all border",
                    mode === 'single' ? "bg-primary/20 text-primary border-primary/20" : "bg-transparent text-muted-foreground border-transparent opacity-50"
                  )}
                 >
                   Tier {tier?.id} Only
                 </button>
                 <button 
                  onClick={() => setMode('all')}
                  className={cn(
                    "text-[10px] font-black uppercase tracking-widest px-2 py-0.5 rounded-full transition-all border flex items-center gap-1",
                    mode === 'all' ? "bg-blue-500/20 text-blue-500 border-blue-500/20" : "bg-transparent text-muted-foreground border-transparent opacity-50"
                  )}
                 >
                   <Globe size={10} /> Full Schema
                 </button>
              </div>
            </div>
          </div>
          
          <div className="flex items-center gap-3">
            <button 
              onClick={handleCopy}
              className="flex items-center gap-2 px-5 py-2.5 rounded-2xl bg-primary text-white text-xs font-black shadow-lg shadow-primary/20 transition-all hover:scale-105 active:scale-95 uppercase tracking-widest"
            >
              {copied ? <Check size={16} strokeWidth={3} /> : <Copy size={16} strokeWidth={3} />}
              {copied ? 'Đã sao chép' : 'Sao chép Script'}
            </button>
            <button onClick={onClose} className="p-3 hover:bg-destructive/10 hover:text-destructive rounded-2xl transition-all">
              <X size={24} />
            </button>
          </div>
        </div>

        <div className="flex-1 overflow-auto bg-black/95 p-8 custom-scrollbar">
          <pre className="text-[13px] font-mono leading-relaxed selection:bg-primary/30">
            {fullSql.split('\n').map((line, i) => (
              <div key={i} className="flex gap-6 group/line hover:bg-white/5 transition-colors px-2 rounded">
                <span className="w-10 text-right text-muted-foreground/20 select-none font-bold">{i + 1}</span>
                <span className={cn(
                  line.trim().startsWith('--') ? "text-emerald-500/80 italic font-medium" : 
                  line.includes('CREATE TABLE') ? "text-pink-400 font-black tracking-tight" : 
                  line.includes('GO') ? "text-orange-400 font-bold" :
                  line.includes('FOREIGN KEY') ? "text-blue-400 font-semibold" :
                  "text-slate-300"
                )}>
                  {line}
                </span>
              </div>
            ))}
          </pre>
        </div>
        
        <div className="p-4 border-t border-border/40 bg-card/20 flex flex-col sm:flex-row items-center justify-between gap-4">
          <div className="flex items-center gap-3 text-muted-foreground">
             <Info size={16} />
             <p className="text-[11px] font-bold uppercase tracking-widest opacity-60">Generated Script is compatible with MS SQL Server / Azure SQL</p>
          </div>
          <button 
            onClick={onClose}
            className="px-8 py-2.5 rounded-2xl bg-accent hover:bg-accent/80 font-black text-xs uppercase tracking-widest transition-all active:scale-95"
          >
            Đóng bảng mã
          </button>
        </div>
      </div>
    </div>
  );
}
