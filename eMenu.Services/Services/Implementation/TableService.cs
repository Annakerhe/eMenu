using AutoMapper;
using eMenu.Entities.Models;
using eMenu.Repository;
using eMenu.Services.Abstract;
using eMenu.Services.Models;

namespace eMenu.Services.Implementation;

public class TableService : ITableService
{
private readonly IRepository<Table> TableRepository;
private readonly IMapper mapper;
public TableService(IRepository<Table> TableRepository, IMapper mapper)
{
this.TableRepository=TableRepository;
this.mapper = mapper;
}

public void DeleteTable(Guid id)
{
var TableToDelete =TableRepository.GetById(id);
if (TableToDelete == null)
{
throw new Exception("Table not found");
}
TableRepository.Delete(TableToDelete);
}

public TableModel GetTable(Guid id)
{
var Table = TableRepository.GetById(id);
return mapper.Map<TableModel>(Table);
}

public PageModel<TablePreviewModel> GetTables(int limit = 20, int offset = 0)
{
var Tables =TableRepository.GetAll();
int totalCount =Tables.Count();
var chunk=Tables.OrderBy(x=>x.Location).Skip(offset).Take(limit);

return new PageModel<TablePreviewModel>()
{
Items = mapper.Map<IEnumerable<TablePreviewModel>>(chunk),
TotalCount = totalCount
};
}

public TableModel UpdateTable (Guid id, UpdateTableModel Table)
{
var existingTable = TableRepository.GetById(id);
if (existingTable == null)
{
throw new Exception("Table not found");
}
existingTable.Location=Table.Location;

existingTable = TableRepository.Save(existingTable);
return mapper.Map<TableModel>(existingTable);
}
public TableModel CreateTable(TableModel tableModel){
    TableRepository.Save(mapper.Map<Entities.Models.Table>(tableModel));
return tableModel;
 }
}