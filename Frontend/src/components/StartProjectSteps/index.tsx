import React from "react";
import Grid from "@material-ui/core/Grid";

import styles from "./style.module.scss";
import { graphql, useStaticQuery } from "gatsby";

const query = graphql`
  query {
    steps: allMarkdownRemark(
      filter: { frontmatter: { type: { eq: "startprojectsteps" } } }
      sort: { fields: frontmatter___sequence }
    ) {
      nodes {
        html
        frontmatter {
          sequence
          name
          image
        }
      }
    }
  }
`;

export const StartProjectSteps = () => {
  const data = useStaticQuery(query);
  const steps = data.steps.nodes;

  return (
    <Grid container className={styles.main}>
      {steps.map((step, index) => (
        <Grid key={index} item xs={12} md={4} className={styles.step}>
          <img
            alt={step.frontmatter.name}
            title={step.frontmatter.name}
            src={step.frontmatter.image}
          ></img>
          <h2>{step.frontmatter.name}</h2>
          <span dangerouslySetInnerHTML={{ __html: step.html }}></span>
        </Grid>
      ))}
    </Grid>
  );
};
