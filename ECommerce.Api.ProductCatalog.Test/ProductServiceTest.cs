using AutoMapper;
using ECommerce.Api.ProductCatalog.Aplication;
using ECommerce.Api.ProductCatalog.Model;
using ECommerce.Api.ProductCatalog.Persistence;
using ECommerce.Api.ProductCatalog.Test.Utils;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ECommerce.Api.ProductCatalog.Test
{
  public class ProductServiceTest
  {
    private IEnumerable<Product> ObtenerDataPrueba()
    {
      // este metodo es para llenar con data de genfu
      A.Configure<Product>()
          .Fill(x => x.Description).AsArticleTitle()
          .Fill(x => x.Category).AsMusicGenreDescription()
          .Fill(x => x.Id, () => { return Guid.NewGuid(); });


      var lista = A.ListOf<Product>(30);
      lista[0].Id = Guid.Empty;

      return lista;
    }

    private Mock<ContextProduct> CrearContexto()
    {

      var dataPrueba = ObtenerDataPrueba().AsQueryable();

      var dbSet = new Mock<DbSet<Product>>();
      dbSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
      dbSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
      dbSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
      dbSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

      dbSet.As<IAsyncEnumerable<Product>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
      .Returns(new AsyncEnumerator<Product>(dataPrueba.GetEnumerator()));


      dbSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Product>(dataPrueba.Provider));


      var contexto = new Mock<ContextProduct>();
      contexto.Setup(x => x.Products).Returns(dbSet.Object);
      return contexto;
    }


    [Fact]
    public async void GetProductById()
    {
      // que metodo dentro de mi microservice producto se esta encargando 
      //de realizar la consulta de productos de la base de datos???

      //1. Emular a la instancia de entity framework core - ContextoProductos
      // para emular la acciones y eventos de un objeto en un ambiente de unit test 
      //utilizamos objetos de tipo mock

      var mockContexto = CrearContexto();

      // 2 Emular al mapping IMapper

      var mapConfig = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new MappingTest());
      });

      var mapper = mapConfig.CreateMapper();
      //3. Instanciar a la clase Manejador y pasarle como parametros los mocks que he creado

      Query.Manager manejador = new Query.Manager(mockContexto.Object, mapper);

      Query.Execute request = new Query.Execute();

      var lista = await manejador.Handle(request, new CancellationToken());

      Assert.True(lista.Any());
    }

    [Fact]
    public async void SaveProduct()
    {
      //Este test es para unit test product
      var options = new DbContextOptionsBuilder<ContextProduct>()
          .UseInMemoryDatabase(databaseName: "BaseDatosProductos")
          .Options;

      var contexto = new ContextProduct(options);

      var request = new New.Execute();
      request.Description = "Libro de Microservice";
      request.Id = Guid.Empty;
      request.DateCreated = DateTime.Now;

      var manejador = new New.Manejador(contexto);

      var libro = await manejador.Handle(request, new CancellationToken());

      Assert.True(libro != null);
    }

  }
}