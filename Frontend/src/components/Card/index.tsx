import React from "react";
import styles from "./style.module.scss";
import { IProject } from "../../api/types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import ProgressRing from "../ProgressRing";

export default ({ project }: { project: IProject }) => {
    const percentage = project.totalParticipants
        ? Math.round(project.totalParticipants / project.target)
        : 0;

  return (
    <a href={project.url} className={styles.card}>
      <figure className={styles.image}>
        {project.descriptiveImage ? (
          <img src={project.descriptiveImage.filepath} alt={project.name} />
        ) : (
          <img
            src={"/assets/default_banners/" + project.categories[0].category + ".jpg"}
            alt={project.name}
          />
        )}
      </figure>
      <div className={styles.content}>
        <div className={styles.statusLabel}>
          {project.isActive ? <span>Signup open</span> : null}
          {project.isComingSoon ? <span>Coming soon</span> : null}
          {project.isClosed ? <span>Signup closed</span> : null}
        </div>
        <h3 className={styles.title}>
          {project.name}
        </h3>
        <div className={styles.description}>
          {project.description}
        </div>
        <div className={styles.stats}>
          <div className={styles.percentage}>
            <ProgressRing progress={percentage} />
          </div>
          <div>
            <div className={styles.count}>
              <span>{project.totalParticipants}</span>
              <span> of {project.target} participants</span>
            </div>
            <div className={styles.remainingTime}>
              <FontAwesomeIcon icon="clock"></FontAwesomeIcon>
              {project.remainingTime ? (
                <span>
                  {Math.round(project.remainingTime / 3600 / 24)} days
                </span>
              ) : (
                <span>not active</span>
              )}
            </div>
          </div>
        </div>
        <div className={styles.category}>
          { project.categories.map(c => c.category).join(" ") }
        </div>
      </div>
    </a>
  );
};
