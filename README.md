
# World Explorer VR

World Explorer VR is an immersive virtual reality experience that allows users to explore detailed and dynamic virtual worlds. This project is developed using Unity and the XR Toolkit.

## Table of Contents
- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Setup](#setup)
- [Deployment](#deployment)
- [Usage](#usage)

## Features
- Immersive VR environments
- Intuitive user interface
- Interactive elements within the VR world
- Cross-platform support

## Requirements
- Unity 2021.3 or later
- XR Plugin Management
- Compatible VR headset (Meta Quest, Oculus Rift)
- Visual Studio or another C# IDE

## Installation
1. **Clone the repository:**
    \`\`\`bash
    git clone [https://github.com/juaquin456/world-explorer-vr.git](https://github.com/juaquin456/world-generation-vr/tree/main)
    \`\`\`
2. **Open the project in Unity:**
   - Launch Unity Hub.
   - Click on "Add" and select the \`world-explorer-vr\` folder.
   - Open the project.

3. **Install required packages:**
   - Go to \`Window\` > \`Package Manager\`.
   - Ensure the following packages are installed:
     - XR Plugin Management
     - XR Interaction Toolkit
     - OpenXR Plugin (if using OpenXR compatible headsets)

## Setup
1. **Configure XR settings:**
   - Go to \`Edit\` > \`Project Settings\` > \`XR Plugin Management\`.
   - Enable the XR plugin for your target platform (e.g., Oculus, OpenXR).

2. **Setup VR camera and rig:**
   - Add an \`XR Rig\` prefab to your scene from the XR Interaction Toolkit.
   - Configure the rig settings as needed.

3. **Import Assets:**
   - Place your VR assets (models, textures, etc.) into the appropriate folders in the \`Assets\` directory.

## Deployment
1. **Build settings:**
   - Go to \`File\` > \`Build Settings\`.
   - Select your target platform (e.g., Windows, Android for Oculus Quest).
   - Ensure the scenes you want to include in the build are added to the "Scenes in Build" list.

2. **Configure player settings:**
   - Go to \`Edit\` > \`Project Settings\` > \`Player\`.
   - Configure settings like company name, product name, and version.
   - Ensure VR support is enabled under the \`XR\` tab.

3. **Build the project:**
   - Click on \`Build\` or \`Build and Run\` to compile your project.
   - Choose the output directory and wait for the build process to complete.

## Usage
- Ensure your VR headset is properly connected and set up.
- Launch the built application.
- Follow the in-app instructions to navigate and explore the VR world.
