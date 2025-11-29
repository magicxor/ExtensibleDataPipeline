# ExtensibleDataPipeline

[![release](https://github.com/magicxor/ExtensibleDataPipeline/actions/workflows/release.yml/badge.svg)](https://github.com/magicxor/ExtensibleDataPipeline/actions/workflows/release.yml)
[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/magicxor/ExtensibleDataPipeline)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

A modular and extensible data pipeline framework for .NET that pulls data from various sources and pushes it to multiple targets using a plugin-based architecture.

![Imgur](https://i.imgur.com/yJM83Th.png)

## ✨ Features

- **Plugin-based architecture** — Easily extend functionality by creating custom data source and target providers
- **Multiple data flows** — Configure multiple independent data pipelines in a single instance
- **Regex filtering** — Include or exclude content using regular expression patterns
- **State persistence** — Automatically tracks processed items to avoid duplicates

## 📦 Built-in Providers

### Data Source Providers

| Provider | Description |
|----------|-------------|
| `DvachThreadDataSourceProvider` | Fetches new threads from 2ch.hk boards |
| `DvachPostDataSourceProvider` | Fetches new posts from 2ch.hk threads |
| `VkFeedDataSourceProvider` | Fetches posts from VK (VKontakte) feed |
| `TelegramChannelDataSourceProvider` | Fetches messages from Telegram channels |

### Target Providers

| Provider | Description |
|----------|-------------|
| `FileTargetProvider` | Saves data to a local file |
| `TelegramTargetProvider` | Sends data to a Telegram chat/channel via bot |

## 🏗️ Architecture

The project uses [System.Composition](https://www.nuget.org/packages/System.Composition) (MEF - Managed Extensibility Framework) to dynamically load plugins at runtime. Providers are automatically discovered by scanning assemblies with names matching `Edp.DataSourceProvider.*` or `Edp.TargetProvider.*`.

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/magicxor/ExtensibleDataPipeline.git
   cd ExtensibleDataPipeline
   ```

2. Build the solution:
   ```bash
   dotnet build
   ```

3. Configure `appsettings.json`

4. Run the CLI:
   ```bash
   dotnet run --project Edp.Cli.NetCore
   ```
