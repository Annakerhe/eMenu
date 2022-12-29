using eMenu.Services.Models;

namespace eMenu.Services.Abstract;

public interface ITableService
{
   TableModel GetTable(Guid id);

   TableModel UpdateTable(Guid id, UpdateTableModel table);

   void DeleteTable(Guid id);

   PageModel<TablePreviewModel> GetTables(int limit = 20, int offset = 0);
   TableModel CreateTable(TableModel tableModel);
}
