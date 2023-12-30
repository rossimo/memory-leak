using Godot;
using Flecs.NET.Core;

public partial class Game : Node2D
{
	private World World = World.Create();
	private Entity Player;

	public override void _Ready()
	{
		base._Ready();

		Player = World.Entity("entity");

		var sprite = GetNode<Sprite2D>("Sprite2D");
		Player.Set(sprite);

		World.Routine(
			filter: World.FilterBuilder().Term<Movement>().Term<Sprite2D>(),
			callback: (Entity entity, ref Movement movement, ref Sprite2D sprite) =>
			{
				sprite.Position += movement.Direction * 10;

				entity.Remove<Movement>();
				movement.Free();
			}
		);
	}

	static StringName UI_LEFT = new StringName("ui_left");
	static StringName UI_RIGHT = new StringName("ui_right");
	static StringName UI_UP = new StringName("ui_up");
	static StringName UI_DOWN = new StringName("ui_down");

	public override void _PhysicsProcess(double delta)
	{
		var movement = Godot.Input.GetVector(UI_LEFT, UI_RIGHT, UI_UP, UI_DOWN).Normalized();
		if (!movement.IsZeroApprox())
		{
			Player.Set(new Movement { Direction = movement });
		}

		World.Progress();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);

		World.Dispose();
	}
}
