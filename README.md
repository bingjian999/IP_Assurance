# IP_Assurance - Word 智能审计辅助加载项

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Word%20%7C%20WPS-lightgrey.svg)](https://products.office.com/word)

> 基于 VSTO 的 Word/WPS 加载项，集成 AI 智能助手、审计文档排版、表格同步、批量处理等功能。支持 Anthropic/OpenAI/DeepSeek 多模型接入和 MCP 工具协议。

## 功能概览

### AI 智能助手
- 多 Provider 支持：Anthropic Claude、OpenAI GPT、DeepSeek、Anthropic 兼容接口
- MCP (Model Context Protocol) 工具集成
- Skill 市场安装/卸载
- 流式对话输出 (SSE)
- 工具调用审批机制
- 对话历史压缩与上下文管理
- 子 Agent 编排

### 审计文档排版
- 段落配置与样式自动更新控制
- 表格配置（重复标题、统一列宽、最大列宽）
- 千分位符、选段求和、日期转换
- 大纲级别快速设置（一级~五级 + 正文）
- 批量替换、去除空白、标记高亮

### Excel 数据同步
- Word 表格 ↔ Excel 双向同步
- 绑定关系管理
- 批量导出/同步

### 批量处理
- 批量转 PDF
- 批量合并文档
- 批量拆分（按固定页/指定页/分节符）
- 重命名文档
- Markdown 导入

### 其他功能
- 桌面钉图（截图/录屏）
- 全局配置管理
- 模板目录（动态扫描模板文件夹）
- 自动检查更新

## 项目结构

```
IP_Assurance/
├── IP_Assurance.sln                     # Visual Studio 解决方案
├── src/
│   ├── CPAHelperForWordRe/              # 主项目 - Word VSTO 加载项
│   │   ├── CPAHelperForWordReRebuild.csproj
│   │   ├── ThisAddIn.cs                 # VSTO 入口
│   │   ├── GlobalUsings.cs              # 全局 using 别名
│   │   ├── AssemblyInfo.cs             # 程序集信息 (v4.0.0.2)
│   │   ├── Properties/                  # 资源与设置
│   │   ├── UI/
│   │   │   ├── Ribbon/                  # Ribbon 选项卡与按钮
│   │   │   │   ├── Ribbon1.cs           # 主 Ribbon (10 组, 50+ 按钮)
│   │   │   │   └── CompositeRibbonExtensibility.cs  # Ribbon XML 合成
│   │   │   └── Forms/                   # 配置窗体 (21 个)
│   │   │       ├── AIAssistantConfigWindow.cs
│   │   │       ├── GlobalConfigWindow.cs
│   │   │       ├── BatchReplaceWindow.cs
│   │   │       ├── ExcelSyncWindow.cs
│   │   │       └── ...
│   │   └── _generated/                  # 反编译生成的类型 (混淆命名)
│   │
│   └── CPAHelperAgentHelper/            # AI Agent 运行时
│       └── CPAHelper/
│           └── Agent/
│               ├── Abstractions/        # 接口与数据模型
│               ├── Adapters/            # JSON 持久化适配器
│               ├── Contracts/           # HTTP/SSE DTO
│               ├── DesktopShell/        # HTTP 桥服务 + 运行时外壳
│               │   ├── DesktopAiBridgeServer.cs      # HTTP 桥服务器
│               │   ├── IDesktopAgentRuntime.cs       # 运行时接口
│               │   └── ...
│               └── Runtime/             # 核心 AI Agent 运行时
│                   ├── AgentRuntime.cs              # 核心运行时
│                   ├── ChatClientFactory.cs          # 多 Provider 工厂
│                   ├── ToolAggregator.cs             # 工具聚合器
│                   ├── McpToolProvider.cs            # MCP 工具集成
│                   └── ...
│
├── lib/                                 # 第三方依赖 DLL (61 个)
├── docs/                                # 开发文档
│   └── ip-assurance-dev-guide.html      # 完整开发指南
└── deploy/                              # 部署参考文件
```

## 技术栈

| 类别 | 技术 |
|------|------|
| 运行时 | .NET Framework 4.8 |
| 宿主 | Microsoft Word (VSTO) / WPS Office |
| AI 框架 | Microsoft Agent Framework (MAF) + Microsoft.Extensions.AI |
| AI Provider | Anthropic SDK, OpenAI SDK, DeepSeek |
| 工具协议 | Model Context Protocol (MCP) |
| 嵌入式浏览器 | Microsoft WebView2 |
| Excel 操作 | EPPlus 8.5 |
| Markdown | Markdig |
| 序列化 | Newtonsoft.Json, System.Text.Json |
| 弹性 | Polly |
| 分词 | Microsoft.ML.Tokenizers |

## 环境要求

- Windows 10/11
- .NET Framework 4.8 SDK
- Visual Studio 2022 (推荐) 或 Visual Studio 2019
- VSTO 开发工具 (Office Developer Tools)
- Microsoft Office Word 2016+ 或 WPS Office
- WebView2 Runtime

## 快速开始

### 1. 克隆仓库

```bash
git clone https://github.com/your-username/IP_Assurance.git
cd IP_Assurance
```

### 2. 打开解决方案

用 Visual Studio 打开 `IP_Assurance.sln`。

### 3. 还原依赖

第三方 DLL 已包含在 `lib/` 目录中，无需 NuGet 还原。项目文件已配置相对路径引用。

### 4. 构建

在 Visual Studio 中按 `Ctrl+Shift+B` 构建，或命令行：

```bash
msbuild IP_Assurance.sln /p:Configuration=Debug
```

### 5. 部署加载项

构建后，将输出 DLL 和 `lib/` 中的依赖 DLL 复制到安装目录，配置注册表：

```powershell
# 注册表配置
$regPath = "HKCU:\Software\Microsoft\Office\Word\Addins\CPAHelperForWordRe"
New-Item -Path $regPath -Force
Set-ItemProperty -Path $regPath -Name "LoadBehavior" -Value 3 -Type DWord
Set-ItemProperty -Path $regPath -Name "Manifest" -Value "file:///C:/path/to/CPAHelperForWordRe.vsto|vstolocal"
```

详细部署步骤请参考 [开发指南](docs/ip-assurance-dev-guide.html)。

## 架构概览

```
┌─────────────────────────────────────────────────────┐
│                   Word / WPS Office                  │
│  ┌────────────────────────────────────────────────┐ │
│  │              IP_Assurance Ribbon Tab            │ │
│  │  ┌──────────┐ ┌──────────┐ ┌────────────────┐ │ │
│  │  │审计排版  │ │Excel同步 │ │ AI 智能助手     │ │ │
│  │  │段落/表格 │ │绑定/同步 │ │ WebView2 面板  │ │ │
│  │  └──────────┘ └──────────┘ └───────┬────────┘ │ │
│  └────────────────────────────────────┼───────────┘ │
│                                       │              │
│  ┌────────────────────────────────────▼───────────┐ │
│  │         DesktopAiBridgeServer (HTTP 桥)         │ │
│  │         localhost:端口 / SSE 流式输出            │ │
│  └────────────────────────────────────┬───────────┘ │
│                                       │              │
│  ┌────────────────────────────────────▼───────────┐ │
│  │              AgentRuntime (核心)                 │ │
│  │  ┌──────────┐ ┌──────────┐ ┌────────────────┐ │ │
│  │  │ChatClient│ │ToolAgg   │ │SessionService  │ │ │
│  │  │Factory   │ │(MCP+内置)│ │(压缩/持久化)   │ │ │
│  │  └────┬─────┘ └──────────┘ └────────────────┘ │ │
│  └───────┼────────────────────────────────────────┘ │
└──────────┼──────────────────────────────────────────┘
           │
    ┌──────▼──────┐
    │ AI Provider  │
    │ Anthropic    │
    │ OpenAI       │
    │ DeepSeek     │
    └─────────────┘
```

## 二次开发指南

### 添加新的 Ribbon 按钮

1. 在 `Ribbon1.cs` 中添加按钮定义
2. 在 `TcDczCZyGu()` 方法中绑定 Click 事件
3. 实现按钮回调逻辑

### 添加新的 AI Provider

1. 在 `ChatClientFactory.cs` 中添加 Provider Profile
2. 实现 `IChatClient` 接口
3. 在 `AIAssistantConfigWindow.cs` 中添加配置 UI

### 添加新的工具

1. 实现 `IToolProvider` 接口（参考 `CalculatorToolProvider.cs`）
2. 在 `ToolAggregator` 中注册
3. 工具将自动对 AI 可用

### 添加新的 UI 窗体

1. 在 `UI/Forms/` 下创建新的窗体类
2. 在 Ribbon 按钮回调中实例化并显示

## 关键文件说明

| 文件 | 说明 |
|------|------|
| `ThisAddIn.cs` | VSTO 加载项入口，处理 Startup/Shutdown 事件 |
| `Ribbon1.cs` | 主 Ribbon 选项卡，10 组 50+ 按钮 |
| `AgentRuntime.cs` | AI Agent 核心运行时，管理会话/工具/模型调用 |
| `DesktopAiBridgeServer.cs` | HTTP 桥服务器，连接 WebView2 前端与 AgentRuntime |
| `ChatClientFactory.cs` | 多 AI Provider 工厂，支持 Anthropic/OpenAI/DeepSeek |
| `ToolAggregator.cs` | 工具目录聚合器，管理内置工具 + MCP 工具 |
| `McpToolProvider.cs` | MCP 协议工具集成 |

## 注意事项

- `_generated/` 目录包含反编译生成的混淆代码，类名为随机字符串，但包含核心业务逻辑实现
- `lib/` 目录包含编译所需的第三方 DLL，请勿删除
- 项目使用 `AllowUnsafeBlocks` 和 `LangVersion=latest`
- Word Interop 引用版本为 15.0 (Office 2013+)，VSTO 运行时版本为 10.0

## License

MIT License - 详见 [LICENSE](LICENSE) 文件

## 相关文档

- [完整开发指南](docs/ip-assurance-dev-guide.html) - 架构详解、源码结构、构建部署
