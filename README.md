# Making Isometric Tilemaps in Unity

1. Create -> 2D object -> Isometric tilemap
2. Assets -> Import new asset -> PNG files of isometric tiles/cubes

Assuming 863 by 1024 PNG isometric cube tiles:
Asset PNGs in inspector tab should be `Texture Type: Sprite (2D and UI)`, and pixels per unit should be 863
Grid cell size should be: `X:1, Y:863/1024, Z:1`
