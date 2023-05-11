extends PanelContainer

signal pin_pressed
signal pressed
signal delete_pressed

var project_id: String
var project_name: String
var project_path: String

@onready var pin_button: ImageButton = get_node("Button/HBoxContainer/ButtonPin")
@onready var button: Button = get_node("Button")
@onready var delete_button: ImageButton = get_node("Button/HBoxContainer/ButtonDelete")
@onready var name_label: Label = get_node("Button/HBoxContainer/CenterContainer/LabelName")
@onready var path_label: Label = get_node("Button/HBoxContainer/CenterContainer2/LabelPath")

func _init(id, name, path):
	super()
	project_id = id
	project_name = name
	project_path = path

# Called when the node enters the scene tree for the first time.
func _ready():
	button.pressed.connect(_on_pressed)
	pin_button.pressed.connect(_on_pin_pressed)
	delete_button.pressed.connect(_on_delete_pressed)
	name_label.text = project_name
	path_label.text = project_path

func _on_pressed():
	pressed.emit()

func _on_pin_pressed():
	pin_pressed.emit()

func _on_delete_pressed():
	delete_pressed.emit()
