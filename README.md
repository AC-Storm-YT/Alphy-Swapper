# 🚀 Alphy Swapper Plugin

Alphy Swapper is an advanced, official plugin for the **Alphy Mod Manager** that allows you to directly manage and swap Rocket League assets (UPK files) entirely offline. 

By running as a native plugin, it completely eliminates the need for manual folder configuration and seamlessly syncs with your main modding environment.

## ✨ Key Features

* **Seamless Integration:** Runs directly inside the Alphy Mod Manager. No need to run or manage a separate program.
* **Zero Configuration:** The plugin uses reflection to automatically read your Rocket League game path directly from Alphy's memory. No settings tab required!
* **Smart Auto-Structuring:** Automatically builds the correct folder hierarchy (e.g., `Body\Fennec (Replaces Breakout)`) and drops the exported swap right inside your active Alphy `mods` folder.
* **Instant UI Refresh:** As soon as a swap is generated, the plugin commands Alphy to instantly refresh its interface. Your newly created mod appears in the grid immediately—no restarts required!
* **Fully Embedded Engine:** The Python backend, encryption keys, and item databases are packed directly into the plugin's `.dll`. No messy external folders or dependencies.

## 🛠️ Setup & Usage

### ⚠️ Prerequisites
The Alphy Swapper engine requires **Python 3.8.0 or newer** to execute the background asset modifications. 

**Crucial Installation Step:** When running the Python installer, you **must UNCHECK** the box that says **"Add Python to PATH"** at the bottom of the window, exactly as shown below:

![Python Installer - Uncheck Add to PATH](https://i.imgur.com/VqKqFra.png)

### Installation
The easiest way to install the Swapper is directly through Alphy:
1. Launch **Alphy Mod Manager**.
2. Click the **Plugins** button at the bottom of the left sidebar.
3. Find Alphy Swapper and click **INSTALL PLUGIN**. Alphy will automatically download the latest version and load it directly into memory.

*(Manual Install: Download `Alphy Swapper.dll` and drop it into `%AppData%\Alphy\Plugins`)*

### Generating a Swap
1. Open Alphy and click **RUN SWAPPER** from the Plugins menu.
2. Select an item category (Body, Decal, Wheels, etc.).
3. Choose the item you want to replace (Target).
4. Choose the item you want to equip (Donor).
5. *(Optional)* Enter a custom folder name for your new mod.
6. Click **GENERATE SWAP**.
7. Close the plugin window, and your new mod will automatically be waiting for you in Alphy's grid!

## 🧠 Credits & Acknowledgements

A massive thank you goes to [Crunchy](https://github.com/CrunchyRL/RLUPKTools). The backend UPK parsing, decryption, and package structure handling in this project would not have been possible without their foundational open-source work on RLUPKTools.