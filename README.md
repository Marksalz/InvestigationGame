# InvestigationGame

InvestigationGame is a .NET 6 console application where players take on the role of an investigator tasked with exposing secret agents using a variety of sensors. The game features multiple agent types, each with unique weaknesses and counterattack abilities, and a range of sensor types with special effects.

## Features

- **Agent Types:** Foot Soldier, Squad Leader, Senior Commander, Organization Leader
- **Sensor Types:** Audio, Thermal, Motion, Pulse, Magnetic, Signal, Light
- **Counterattacks:** Higher-level agents can counterattack and remove sensors
- **Sensor Abilities:** Some sensors can reveal agent weaknesses or information
- **Progression:** Investigate agents in order, unlocking higher ranks as you succeed

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Build and Run

1. Clone the repository: git clone <repository-url> cd InvestigationGame

2. Build the project: dotnet build

3. Run the game: dotnet run --project InvestigationGame

## How to Play

1. Enter your name when prompted.
2. Review the list of generated agents and their weaknesses.
3. Investigate agents in order. For each agent:
   - Choose sensors to attach.
   - Some sensors may break or reveal information.
   - Higher-level agents may counterattack and remove your sensors.
   - Expose all weaknesses to succeed and progress.
4. The game ends when all agents are investigated or you choose to exit.

## Project Structure

- `Program.cs` - Main entry point and game loop
- `Agents/` - Agent classes with unique behaviors
- `Factories/` - Factories for creating agents and sensors
- `Manager/` - Investigation manager handling sensor attachment and agent logic
- `Interface/` - Interfaces for agents and sensors
- `Sensors/` - Sensor implementations
- `Enums.cs` - Enumerations for agent and sensor types

## Extending the Game

- Add new agent or sensor types by implementing the relevant interfaces.
- Enhance agent counterattack logic or sensor abilities for more complex gameplay.

## License

This project is licensed under the MIT License.

---

Enjoy investigating!
