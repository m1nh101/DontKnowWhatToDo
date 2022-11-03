using Application.Entities;

namespace Application.Specifications;

public class StudentGreaterThan20Specification
  : Specification<Student>
{
	public StudentGreaterThan20Specification(int age)
		:base(e => e.Age > age)
	{
		
		AddOrderByDescending(e => e.Name);
	}
}