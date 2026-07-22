extends Node
func _ready():
	DiscordRPC.app_id = 1529291037934354463
	DiscordRPC.details = "Puzzles solved: %d/9" % PathManager.PuzzlesSolved()
	DiscordRPC.state = "Puzzles solved: %d/9" % PathManager.PuzzlesSolved()
	DiscordRPC.large_image = "logo" 
	DiscordRPC.start_timestamp = int(Time.get_unix_time_from_system())
	DiscordRPC.refresh()

func update_details(msg: String):
	DiscordRPC.details = msg
	DiscordRPC.refresh()

func update_state(solved: int):
	DiscordRPC.state = "Puzzles solved: %d/9" % solved
	DiscordRPC.refresh()

func update_location(world: String):
	DiscordRPC.small_image = world.to_lower()
	DiscordRPC.small_image_text = "%s World" % world
	DiscordRPC.refresh()
	
func clear_location():
	DiscordRPC.small_image = ""
	DiscordRPC.small_image_text = ""
	DiscordRPC.refresh()
