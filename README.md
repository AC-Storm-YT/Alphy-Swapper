# 🚀 Alphy Swapper

Alphy Swapper is a standalone desktop application that allows you to directly manage and swap Rocket League assets (UPK files).

## ✨ Key Features

* **Direct UPK Editing:** Dynamically injects your chosen assets directly into the game's package files.
* **Auto-Structuring:** Seamlessly integrates with the original **Alphy Mod Manager**. If linked, the swapper automatically builds the correct folder hierarchy (e.g., `Body\Fennec (Replaces Breakout)`) and drops the exported file right inside. (ALPHY ONLY)
* **Custom Folder Naming:** Full control over your export names with an optional custom text box. (ALPHY ONLY)
* **Fully Embedded Engine:** The Python backend, encryption keys, and item databases are packed directly into the `.exe`. No messy external folders required.

## 🛠️ Setup & Usage

1. Download and run `Alphy Swapper.exe`.
2. Navigate to the **Settings** tab:
   * **Game Files Directory:** Link your Rocket League `CookedPCConsole` folder.
   * **Fallback Output Directory:** Select where you want standalone mods saved.
   * **Alphy Mods Directory (Optional):** Link your existing Alphy 1.x mods folder to enable automated sub-folder structuring.
3. Navigate to the **Asset Swapper** tab:
   * Select an item category (Body, Decal, Wheels, etc.).
   * Choose the item you want to replace (Target).
   * Choose the item you want to replace it with (Donor).
   * Click **Execute Asset Swap**.

## 🧠 Credits & Acknowledgements

A massive thank you goes to [Crunchy](https://github.com/CrunchyRL/RLUPKTools). The backend UPK parsing, decryption, and package structure handling in this project would not have been possible without their foundational open-source work on RLUPKTools.
