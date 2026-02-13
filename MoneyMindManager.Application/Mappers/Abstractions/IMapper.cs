namespace MoneyMindManager.Application.Abstractions.Mappers
{
    public interface IMapper<Entity, DTO>
    {
        Entity DTOToEntity(DTO personDTO);

        DTO EntityToDTO(Entity person);
    }
}
