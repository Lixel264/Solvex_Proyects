import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import { fetchHero } from "../libs/utils";

export default function HeroDetails() {
  let { id } = useParams();

  const [hero, setHero] = useState();

  let name;
  let description;
  let thumbnailPath;
  let thumbnailExtension;
  let thumbnailUrl;
  let comics;

  useEffect(() => {
    fetchHero(id)
      .then((data) => setHero(data))
      .catch((err) => console.error(err));
  }, []);

  if (hero) {
    name = hero.data.results[0].name;
    description = hero.data.results[0].description;
    thumbnailPath = hero.data.results[0].thumbnail.path;
    thumbnailExtension = hero.data.results[0].thumbnail.extension;
    thumbnailUrl = `${thumbnailPath}.${thumbnailExtension}`;
    comics = hero.data.results[0].comics.items;
  }

  if (!hero) return;

  return (
    <div className="container large">
      <div className="hero__details-container">
        <img src={thumbnailUrl} alt="hero image full size" />
        <div className="hero__details">
          <br />
          <h4>Name</h4>
          <p>{name}</p>
          {description ? (
            <>
              <h4>Description</h4>
              <p>{description}</p>
            </>
          ) : null}
          <div className="hero__comics">
            <h4>Comics</h4>
            <ul>
              {comics
                ? comics.map((title) => (
                    <li key={Math.random() * 1000}>{title.name}</li>
                  ))
                : null}
            </ul>

            <br />
            
          </div>
        </div>
      </div>
    </div>
  );
}
