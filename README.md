# Alphy Swapper Plugin

Alphy Swapper is an advanced, official plugin for the **Alphy Mod Manager** that lets you generate custom Rocket League cosmetic swaps from supported UPK assets.

It runs directly inside Alphy, reads the game path from the main app, exports generated swaps into your Alphy `mods` folder, and refreshes the mod list automatically.

> **Repository Notice:** Starting after **Alphy Swapper v1.0.3**, official plugin builds are closed-source. The public repository remains available for history, downloads, documentation, and legacy source code up to v1.0.3.

---

## Key Features

* **Seamless Integration:** Runs directly inside Alphy. No separate launcher or manual folder linking required.
* **Smart Exporting:** Automatically builds the correct folder structure, such as `Body/Fennec (Replaces Breakout)`, and places the generated mod in Alphy's active `mods` folder.
* **Instant Refresh:** After a swap is generated, the plugin tells Alphy to refresh the mod grid immediately.
* **Selectable Engines:** Choose between RLUPKTools, Alphy, and Alphy Pro depending on the swap you are generating.
* **Automatic Backend Setup:** The plugin checks for Python and required packages such as `cryptography`. If needed, it can prepare a portable Python backend inside `%AppData%\AlphySwapper\Backend`.

---

## Swapping Engines

### RLUPKTools (Default)

The default and recommended engine for normal use. It is designed to safely rebuild supported UPK swaps and should be used first.

### Alphy

A simpler fallback engine for cases where a specific swap does not work correctly with the default RLUPKTools engine.

### Alphy Pro [BETA]

Alphy Pro is a beta-only engine available to users with beta feature access in the official Alphy Discord server.

Everyone can see the option in the engine dropdown, but only authorized beta testers can select and use it.

---

## Setup & Usage

### Installation

The easiest way to install Alphy Swapper is through Alphy:

1. Launch **Alphy Mod Manager**.
2. Authorize your Discord account if prompted.
3. Click the **Plugins** button.
4. Find **Alphy Swapper** and click **INSTALL PLUGIN**.
5. Open the plugin from the Plugins menu.

### Generating a Swap

1. Open Alphy and click **RUN SWAPPER** from the Plugins menu.
2. Select an item category, such as Body, Decal, Wheels, or Boost.
3. Choose the item you want to replace.
4. Choose the item you want to display instead.
5. Optional: enter a custom folder name.
6. Optional: switch engines if the default engine does not work for that swap.
7. Click **GENERATE SWAP**.
8. The generated mod will appear in Alphy's grid.

---

## Discord Access & Privacy

Alphy Swapper runs inside Alphy, so access is controlled by Alphy's Discord authorization system.

Alphy does **not** receive your Discord password, email, private messages, friends list, or Rocket League account information. Discord handles the authorization page directly.

Alphy only uses the Discord authorization result needed to verify your Discord account, avatar, server membership, and roles in the official Alphy server. Those roles decide whether you can use the app, plugins, custom mods, or beta-only features such as Alphy Pro.

Alphy's authorization service is hosted through Cloudflare. Like most web and API infrastructure providers, Cloudflare may process standard request metadata needed to route, secure, and debug requests, such as IP address, approximate location/network information, user agent, timestamps, request paths, and diagnostic logs.

Alphy does not use Cloudflare request metadata to profile users. It is used only as part of the infrastructure that runs the authorization service.

---

## Repository Status

Alphy Swapper is transitioning to closed-source official builds after **v1.0.3**.

The public repository remains available for:

* Downloading official releases.
* Reading the latest README and usage information.
* Preserving legacy source code up to **Alphy Swapper v1.0.3**.

This change was made because Alphy v2.0.0 and newer builds connect to cloud infrastructure, Discord authorization, and role-based permissions. Keeping backend routing and permission logic public would make the official service easier to abuse.

Official builds remain **clean and unobfuscated**.

