using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using board;

public class IndexModel : PageModel
{
    private readonly GameBoard _gameBoard;

    public Cell[,] Board => _gameBoard.Board;
    public int Turn { get; private set; } = 0;
    public int MaxTurns { get; private set; } = 30;

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
        _gameBoard.PlaceMine(row, column);
        return Page();
    }
}