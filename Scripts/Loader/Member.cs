

public enum MemberType
{
    way = 0,
    relation = 1
}
public enum RoleType
{
    left = 0,
    right = 1,
    regulatory_element = 2,
    refers = 3,
    ref_line = 4

}

public class Member
{
    public MemberType menberType;
    public int refID;
    public RoleType roleType;
}
