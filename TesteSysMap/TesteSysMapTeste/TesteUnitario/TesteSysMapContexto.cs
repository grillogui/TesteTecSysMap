using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using TesteSysMap.src.contexto;
using TesteSysMap.src.modelos;


namespace TesteSysMapTesteUnitario.TesteUnitario
{
    [TestClass]
    public class TesteSysMapContextoTeste
    {
        private TesteSysMapContexto _contexto;

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<TesteSysMapContexto>()
                .UseInMemoryDatabase(databaseName: "db_SysMap")
                .Options;

            _contexto = new TesteSysMapContexto(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornaUsuario()
        {
            UsuarioModelo Usuario = new UsuarioModelo();

            Usuario.Nome = "Guilherme Grillo";
            Usuario.Email = "guigs@email.com";
            Usuario.DataNascimento = "05/05/2000";
            Usuario.Senha = "senha1234";
            Usuario.Foto = "LINKDAFOTO";

            _contexto.Usuarios.Add(Usuario);

            _contexto.SaveChanges();

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "guigs@email.com"));
        }
    }
}