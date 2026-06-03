# Alphy Swapper Plugin

Alphy Swapper is the official swapping plugin for **Alphy Mod Manager**. It lets you generate Rocket League cosmetic swaps from supported UPK assets directly inside Alphy.

The plugin reads your Rocket League folder from Alphy, exports generated swaps into your Alphy `mods` folder, and refreshes the mod list automatically after a successful swap.

> **Repository Notice:** Starting after **Alphy Swapper v1.0.3**, official plugin builds are closed-source. The public repository remains available for history, downloads, documentation, and legacy source code up to v1.0.3.

---

## Key Features

* **Seamless Alphy Integration:** Runs directly inside Alphy. No separate launcher or manual folder linking required.
* **Smart Exporting:** Automatically builds the correct folder structure, such as `Body/Fennec (Replaces Octane)`, and places the generated mod in Alphy's active `mods` folder.
* **Instant Refresh:** After a swap is generated, Alphy refreshes the mod grid so the new mod appears without restarting.
* **Multiple Swapping Engines:** Choose between Alphy Pro (Extreme), Alphy Pro, Alphy (Outdated), and RLUPKTools depending on the swap you are generating.
* **Embedded Pro Engines:** Alphy Pro and Alphy Pro (Extreme) run from inside the plugin instead of being exported as visible backend Python files.
* **Automatic Backend Setup:** The plugin checks for Python and required packages such as `cryptography`. If needed, it can prepare a portable Python backend inside `%AppData%\AlphySwapper\Backend`.

---

## Swapping Engines

The engine dropdown is ordered from the recommended engine to the older fallback engines:

1. **Alphy Pro (Extreme) (Default)**
2. **Alphy Pro**
3. **Alphy (Outdated)**
4. **RLUPKTools**

### Alphy Pro (Extreme) (Default)

The default and recommended engine. Alphy Pro (Extreme) is designed to generate safer swaps by validating output before exporting it and blocking risky swaps that are likely to crash the game.

Use this engine first for most swaps.

### Alphy Pro

A strict Pro engine with additional verification and safer output handling compared to the older fallback engines.

Use this if Alphy Pro (Extreme) does not work correctly for a specific swap.

### Alphy (Outdated)

The older Alphy fallback engine. It is still available for compatibility, but it is no longer the recommended engine.

Use it only if a specific swap does not work correctly with the Pro engines.

### RLUPKTools

The original RLUPKTools-based engine. It remains available as a legacy option and may still be useful for certain compatible swaps.

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

> Some Rocket League asset combinations may still be incompatible. When Alphy Pro or Alphy Pro (Extreme) detects an unsafe output, the swap may be blocked instead of exported. This is intentional and helps prevent broken mods from crashing the game.

---

## Backend Files

Alphy Swapper may create or update backend files in:

```txt
%AppData%\AlphySwapper\Backend
```

These files are used for shared data, keys, Python support, and legacy engines.

Alphy Pro and Alphy Pro (Extreme) are handled differently: their engine scripts are embedded inside `Alphy Swapper.dll` and are not exported to the backend folder. If older versions left Pro engine scripts in the backend folder, newer builds remove them automatically.

---

## Discord Access & Privacy

Alphy Swapper runs inside Alphy, so access is controlled by Alphy's Discord authorization system.

Alphy does **not** receive your Discord password, email, private messages, friends list, or Rocket League account information. Discord handles the authorization page directly.

Alphy only uses the Discord authorization result needed to verify your Discord account, avatar, server membership, and roles in the official Alphy server. Those roles decide whether you can use the app, plugins, custom mods, and future role-based features.

Alphy's authorization service is hosted through Cloudflare. Like most web and API infrastructure providers, Cloudflare may process standard request metadata needed to route, secure, and debug requests, such as IP address, approximate location/network information, user agent, timestamps, request paths, and diagnostic logs.

Alphy does not use Cloudflare request metadata to profile users. It is used only as part of the infrastructure that runs the authorization service.

---

## Repository Status

Alphy Swapper official builds are closed-source after **v1.0.3**.

The public repository remains available for:

* Downloading official releases.
* Reading the latest README and usage information.
* Preserving legacy source code up to **Alphy Swapper v1.0.3**.

This change was made because newer Alphy and Alphy Swapper builds connect to cloud infrastructure, Discord authorization, role-based permissions, and protected engine logic. Keeping backend routing and protected engine code public would make the official service easier to abuse.

---

## Credits & Acknowledgements

Shadxw also provided his work for the swapping system used in [Oryx](https://discord.gg/sWhS6F8v9a), which allowed me to create a fallback engine for Alphy Swapper **v1.1.0**.

Additional thanks to Crunchy and [RLUPKTools](https://github.com/CrunchyRL/RLUPKTools) for the foundational technical research.
