import java.util.Date;
import java.util.*;

public class Student 
{
	private String firstName;
	private String lastName;
	private String middleInitial;
	private int universityId;
	private Date universityStartDate;
	private Date universityEndDate;
	private String status;
	private Emphasis emphasis;
	
	/**
	 * Constructor
	 * @param fName Student's First Name
	 * @param lName Student's Last Name
	 * @param mInitial Student's Middle Initials
	 * @param stat Student Status
	 * @param id Student's university id
	 * @param startDate University Start Date
	 * @param endDate University End Date
	 * @param emph The student's emphasis, can be undeclared.
	 */
	public Student(String fName, String lName, String mInitial, String stat, int id, Date startDate, Date endDate, Emphasis emph)
	{
		firstName = fName;
		lastName = lName;
		middleInitial = mInitial;
		status = stat;
		universityId = id;
		universityStartDate = startDate;
		universityEndDate = endDate;
		emphasis = emph;
	}
	
	/**
	 * Constructor
	 * @param fName Student's First Name
	 * @param lName Student's Last Name
	 * @param mInitial Student's Middle Initial
	 * @param id Student's university id
	 * @param emph A student's emphasis
	 */
	public Student(String fName, String lName, String mInitial, int id, Emphasis emph)
	{
		firstName = fName;
		lastName = lName;
		middleInitial = mInitial;
		universityId = id;
		emphasis = emph;
	}
	
	/**
	 * Constructor
	 * @param fName Student's First Name
	 * @param lName Student's Last Name
	 * @param mInitial Student's Middle Initial
	 * @param id Student's university id
	 */
	public Student(String fName, String lName, String mInitial, int id)
	{
		firstName = fName;
		lastName = lName;
		middleInitial = mInitial;
		universityId = id;
	}
}
