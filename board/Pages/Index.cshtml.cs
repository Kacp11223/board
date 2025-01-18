using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using board;

public class IndexModel : PageModel
{
    private readonly GameBoard _gameBoard;

    public Cell[,] Board => _gameBoard.Board;
    public int Turn { get; private set; } = 0;
    public int MaxTurns { get; private set; } = 30;
    public int RemainingMines => 4 - _gameBoard.GetCurrentMines();

    public IndexModel(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPostNextTurn()
    {
        if (Turn < MaxTurns)
        {
            Turn++;
            _gameBoard.MoveCreatures();
        }
        return Page();
    }

    public IActionResult OnPostCellClick(int row, int column)
    {
        if (_gameBoard.CanPlaceMine(row, column))
        {
            _gameBoard.PlaceMine(row, column);
        }
        return Page();
    }
}