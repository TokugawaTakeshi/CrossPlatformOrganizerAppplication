﻿namespace CommonSolution.Entities;


public class Task
{

  public required string ID { get; init; }

  
  public required string title { get; set; }
  
  public abstract class Title
  {
    public const bool IS_REQUIRED = true;
    public const byte MINIMAL_CHARACTERS_COUNT = 2;
    public const byte MAXIMAL_CHARACTERS_COUNT = Byte.MaxValue;
  }

  
  public string? description { get; set; }
  
  public abstract class Description
  {
    public const bool IS_REQUIRED = false;
    public const byte MINIMAL_CHARACTERS_COUNT = 2;
  }
  
  
  public bool isComplete { get; set; } = false;
  
  public abstract class IsComplete
  {
    public const bool IS_REQUIRED = false;
  }


  public List<Task> subtasks { get; set; } = new(); 
  
  public abstract class Subtasks
  {
    public const bool IS_REQUIRED = true;
  }


  protected DateTime? _associatedDateTime;
  protected DateOnly? _associatedDate;

  public DateTime? associatedDateTime
  {
    get => this._associatedDateTime;
    set
    {
      this._associatedDateTime = value;
      this._associatedDate = null;
    }
  }
  
  public abstract class AssociatedDateTime
  {
    public const bool IS_REQUIRED = true;
  } 

  public DateOnly? associatedDate
  {
    get => this._associatedDate;
    set
    {
      this._associatedDate = value;
      this._associatedDateTime = null;
    }
  }
  
  public abstract class AssociatedDate
  {
    public const bool IS_REQUIRED = true;
  } 


  public CommonSolution.Entities.Location? associatedLocation { get; set; }
  
  public abstract class AssociatedLocation
  {
    public const bool IS_REQUIRED = false;
  } 

}