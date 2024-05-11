using System.Diagnostics;
using Godot;

public partial class player_game_of_life_anim : Node
{
	[Export]
	float gol_timer = 1f;

	RandomNumberGenerator rng;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        rng = new RandomNumberGenerator();

		GenerateGameOfLifePattern();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		gol_timer -= (float)delta;

		if(gol_timer < 0f)
        {
            gol_timer = 1f;

            GenerateGameOfLifePattern();
		}
	}

	//Sets the cells sprites to be visible or not on a random basis
	public void GenerateGameOfLifePattern(){
        Debug.WriteLine("Changing pattern on player");

		//FOR loop going from 1 to 6 for naming convention
        for (int i = 1; i < 7; i++){
			for(int j = 1; j < 7; j++){
				Node row = FindChild("AntiRow" + i.ToString(), true);
				Node2D cell = (Node2D)row.FindChild("AntiCell" + j.ToString(), false);

				cell.Visible = rng.Randf() > 0.6f;
			}
		}
	}
}
