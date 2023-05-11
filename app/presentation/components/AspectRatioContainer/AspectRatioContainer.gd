@tool

# Represents an AspectRatioContainer with a hacky fix to its behavior, 
# so that it actually maintains its aspect ratio, depending checked its
# stretch_mode. 
extends AspectRatioContainer

func _ready():
	connect("resized",Callable(self,"_on_resized"))
	_do_size_hack()
	
func _on_resized():
	_do_size_hack()

func _do_size_hack():
	if (self.stretch_mode == STRETCH_HEIGHT_CONTROLS_WIDTH):
		self.minimum_size.x = self.size.y
		self.minimum_size.y = self.size.y
	elif (self.stretch_mode == STRETCH_WIDTH_CONTROLS_HEIGHT):
		self.minimum_size.x = self.size.x
		self.minimum_size.y = self.size.x
