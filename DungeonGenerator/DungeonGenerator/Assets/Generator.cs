using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

	[SerializeField] private GameObject _gridObject;
	[SerializeField] private GameObject _startBlock;
	[SerializeField] private GameObject _dungeonBlock;

	[SerializeField] private int _height;
	[SerializeField] private int _length;

	[SerializeField] private int _size;

	private enum Direction {Up, Down, Left, Right}
	Direction _currentDir;

	private int _currentX;
	private int _currentY;
	
	private GameObject[,] _grid;	

	void Start ()
	{		
		_currentX = Random.Range(0, _length);
		_currentY = Random.Range(0, _height);
		
		
		_grid = new GameObject[_height,_length];
		
		
		for (int x = 0; x < _length; x++)
		{
			
			for (int y = 0; y < _height; y++)
			{
				if (x ==  _currentX && y == _currentY)
				{
					_grid[_currentX, _currentY] = Instantiate(_startBlock, new Vector3(x, y, 0), Quaternion.identity);
				}
				else
				{
					_grid[x, y] = Instantiate(_gridObject, new Vector3(x, y, 0), Quaternion.identity);
				}
			}
		}
		GenerateDungeon();
		
	}

	void GenerateDungeon()
	{
		for (int i = 0; i < _size; i++)
		{
			_currentDir = (Direction)Random.Range(0, 4);
			switch(_currentDir)
			{
				case Direction.Down:
					_currentY--;
					break;
				
				case Direction.Up:
					_currentY++;
					break;
				
				case Direction.Left:
					_currentX--;
					break;
				
				case Direction.Right:
					_currentX++;		
					break;
			}	
			CheckIndex();
			_grid[_currentX, _currentY] = Instantiate(_dungeonBlock, new Vector3(_currentX,_currentY,0), Quaternion.identity);

		}
	}

	void CheckIndex()
	{
		
		if (_currentX >= _length)
		{
			print("1:" + _currentX + " " + _currentY);
			_currentX = 0; 
			print("1.2:" + _currentX + " " + _currentY);
		}
		else if (_currentX < 0)
		{
			print("2:" + _currentX + " " + _currentY);
			_currentX = _length-2;
			print("2.2:" + _currentX + " " + _currentY);
		}

		if (_currentY >= _height)
		{
			print("3:" + _currentX + " " + _currentY);
			_currentY = 0;
			print("3.2:" + _currentX + " " + _currentY);
		}
		else if (_currentY < 0)
		{
			print("4:" + _currentX + " " + _currentY);
			_currentY = _height-2 ;
			print("4.2:" + _currentX + " " + _currentY);
		}
	}
}
