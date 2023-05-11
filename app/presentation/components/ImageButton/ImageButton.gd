@tool
class_name ImageButton extends AspectRatioContainer

@export
var image_texture: Texture2D;

@export
var toggle: bool = false:
	get: 
		return toggle
	set(value):
		button.toggle_mode = value

@export
var disabled: bool = false:
	get: 
		return disabled
	set(value):
		button.disabled = value

@onready var texture_rect: TextureRect = get_node("Button/MarginContainer/TextureRect")
@onready var button: Button = get_node("Button")

signal pressed
signal toggled

# Called when the node enters the scene tree for the first time.
func _ready():
	texture_rect.texture = image_texture
	button.toggle_mode = toggle
	button.disabled = disabled
	button.pressed.connect(_on_pressed)
	button.toggled.connect(_on_toggled)

func _on_pressed():
	pressed.emit()

func _on_toggled():
	toggled.emit()

