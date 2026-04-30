# VisB-3D Unity Visualization

This repository contains the Unity 3D visualization used in VisB-3D. 
VisB-3D is an extension of VisB for ProB2-UI, which introduces interactive three-dimensional visualizations for state-based formal models.

The visualization built is integrated into VisB-3D within ProB2-UI. Therefore, this repository cannot be used independently.
To learn more about VisB-3D and ProB2-UI, please visit the ProB wiki: https://prob.hhu.de/w/index.php/ProB2-UI

## Context

VisB-3D extends the VisB visualization framework for ProB by introducing support for interactive 3D visualizations of formal models. While traditional VisB visualizations are limited to two dimensions, VisB-3D targets application domains where spatial representation improves clarity and interpretability.

This repository implements the Unity-based rendering and interaction layer of the system.

## System Overview

The overall system consists of two tightly coupled components:

- **ProB2-UI with VisB-3D extension (backend, Java)**
  - Executes formal models and manages state
  - Hosts the WebGL build of the Unity visualization
  - Sends visualization updates to the Unity frontend

- **Unity Visualization (this repository)**
  - Receives state updates from ProB2-UI
  - Renders and updates interactive visualizations in real time
  - Provides user interaction within the 3D environment

## 3D Glue Format

The visualization is driven by a dedicated 3D glue format, which defines how elements of a formal model are mapped to a 3D scene. This includes:

- Mapping of model variables to 3D objects
- Definition of transformations (position, rotation, scale)
- Material and appearance configuration
- Camera setup and scene layout

This allows a declarative specification of visualization behavior independent of the Unity implementation.

## Repository Scope

This repository contains:

- Unity project for rendering and interaction
- Scene and asset configuration for VisB-3D
- Logic for processing incoming visualization messages
- Mapping of state updates to 3D scene changes

It does not contain the ProB2-UI backend or any example models.

## Related Work

- ProB2-UI: https://prob.hhu.de/w/index.php/ProB2-UI  
- VisB-3D examples: https://gitlab.cs.uni-duesseldorf.de/general/stups/visb-visualisation-examples/-/tree/master/VisB-3D  
- ProB2-UI VisB-3D extension: https://github.com/DerHyper/ProB2-UI-VisB-3D 