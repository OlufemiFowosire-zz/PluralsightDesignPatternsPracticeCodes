namespace ProtectiveProxy
{
    public enum Roles
    {
        Author,
        Editor
    }

    /**
      * Author can create a new Document
      * Author can update the name of the document, modify its content, and assign initial tags
      * Author can submit document for review by an Editor
      * Editor can edit tags
      * Editor can mark the document reviewd (sets DateReviewed)
      * Editor cannot modify Name or Content directly
      * May be add Admin who can do anything (later)
      * */
}