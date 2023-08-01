using System.Text.RegularExpressions;
using Base.Entities;
using Base.Exceptions;

namespace Domain.Entities;

public class Master : Entity
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }
    public IList<Pokemon> Pokemons { get; private set; }

    public Master(string name, DateTime birthDate, string email, string document)
    {
        SetName(name);
        SetBirthDate(birthDate);
        SetEmail(email);
        SetDocument(document);
    }
    
    public void SetBirthDate(DateTime birthDate)
    {
        if (birthDate > DateTime.Now.AddYears(-8))
        {
            throw new AppException("The Pokemon Master must be at least 8 years old");
        }
        
        BirthDate = birthDate;
    }
    
    public void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new AppException("Email cannot be null or empty");
        }
        
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        
        if (!emailRegex.IsMatch(email))
        {
            throw new AppException("Invalid email");
        }

        Email = email;
    }
    
    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new AppException("Name cannot be null or empty");
        }
        
        Name = name;
    }
    
    public void SetDocument(string document)
    {
        if (string.IsNullOrEmpty(document))
        {
            throw new AppException("Document cannot be null or empty");
        }
        
        var documentRegex = new Regex(@"^[0-9]*$");
        
        if (!documentRegex.IsMatch(document))
        {
            throw new AppException("Invalid document");
        }

        Document = document;
    }
    
    public void CapturePokemon(Pokemon pokemonId)
    {
        if (Pokemons.Contains(pokemonId))
        {
            throw new AppException("Pokemon already captured");
        }
        
        Pokemons.Add(pokemonId);
    }
}