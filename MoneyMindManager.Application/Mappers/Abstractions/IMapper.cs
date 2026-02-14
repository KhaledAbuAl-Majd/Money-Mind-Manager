namespace MoneyMindManager.Application.Abstractions.Mappers
{
    public interface IMapper<Entity, DTO>
    {
        Entity DTOToEntity(DTO DTO);

        DTO EntityToDTO(Entity entity);
    }
}
