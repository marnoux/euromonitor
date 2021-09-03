using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
  public partial class SeedData : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "Books",
          columns: new[] { "Id", "Name", "Text", "Price" },
          values: new object[,]
            {
              { 1, "Don Quixote",
              "The Ingenious Gentleman Don Quixote of La Mancha, or just Don Quixote, is a Spanish novel by Miguel de Cervantes. It was originally published in two parts, in 1605 and 1615. A founding work of Western literature, it is often labeled as the first modern novel and is considered one of the greatest works ever written.", 99.99 },
              { 2, "A Tale of Two Cities",
              "A Tale of Two Cities is Charles Dickens’s great historical novel, set against the violent upheaval of the French Revolution. The most famous and perhaps the most popular of his works, it compresses an event of immense complexity to the scale of a family history, with a cast of characters that includes a bloodthirsty ogress and an antihero as believably flawed as any in modern fiction. Though the least typical of the author’s novels, A Tale of Two Cities still underscores many of his enduring themes—imprisonment, injustice, social anarchy, resurrection, and the renunciation that fosters renewal.", 199.99 },
              { 3, "The Lord of the Rings",
              "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel written by J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring, The Two Towers, and The Return of the King.", 49.99 },
              { 4, "The Little Prince",
              "The Little Prince is a novella by French aristocrat, writer, and aviator Antoine de Saint-Exupéry. It was first published in English and French in the US by Reynal & Hitchcock in April 1943, and posthumously in France following the liberation of France as Saint-Exupéry's works had been banned by the Vichy Regime.", 249.99 },
              { 5, "Harry Potter and the Sorcerer's Stone",
              "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.", 29.99 },
              { 6, "And Then There Were None",
              "And Then There Were None is a dramatic adaptation of the best-selling crime novel by Agatha Christie. The story follows 10 strangers who receive an unusual invitation to a solitary mansion based remotely off Britain's Devon Coast. Among the guests is an unstable doctor, an anxious businessman, an irresponsible playboy, and a governess with a secret. Cut off from the outside world, the group arrives at its destination, only to find that darkness awaits them. As people start to mysteriously die, the members of the group realize there is a killer among them.", 149.99 },
              { 7, "The Dream of the Red Chamber",
              "Dream of the Red Chamber, also called The Story of the Stone, or Hongloumeng, composed by Cao Xueqin, is one of China's Four Great Classical Novels. It was written some time in the middle of the 18th century during the Qing dynasty.", 69.99 },
            }
          );
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
