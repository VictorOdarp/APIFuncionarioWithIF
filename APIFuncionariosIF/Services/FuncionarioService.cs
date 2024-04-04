using APIFuncionariosIF.DataContext;
using APIFuncionariosIF.Interface;
using APIFuncionariosIF.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace APIFuncionariosIF.Services
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly APIFuncionariosIFContext _context;

        public FuncionarioService(APIFuncionariosIFContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Data = await _context.Funcionario.ToListAsync();

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                if (id == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Success = false;
                }

                FuncionarioModel funcionario = await _context.Funcionario.FirstOrDefaultAsync(X => X.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionarie)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (newFuncionarie == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                _context.Add(newFuncionarie);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Funcionario.ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (editFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                FuncionarioModel Funcionario = await _context.Funcionario.AsNoTracking().FirstOrDefaultAsync(X => X.Id == editFuncionario.Id);

                if (Funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Update(editFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Funcionario.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (id == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                FuncionarioModel funcionario = await _context.Funcionario.FirstOrDefaultAsync(X => X.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Funcionario.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (id == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                FuncionarioModel funcionario = await _context.Funcionario.FirstOrDefaultAsync(X => X.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                funcionario.Active = false;
                funcionario.ChangeDate = DateTime.Now.ToLocalTime();

                _context.Funcionario.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Funcionario.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
