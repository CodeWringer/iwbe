extends Control

@onready var button_canvas: Button = get_node("VBoxContainer/ButtonWorkspaceCanvas")
@onready var button_articles: Button = get_node("VBoxContainer/ButtonWorkspaceArticles")
@onready var main: Control = get_tree().get_root().get_node("Main")

# Called when the node enters the scene tree for the first time.
func _ready():
	button_canvas.pressed.connect(_canvas_pressed)
	button_articles.pressed.connect(_articles_pressed)

func _canvas_pressed():
	pass

func _articles_pressed():
	main.call("SetWorkspace", "articles")
