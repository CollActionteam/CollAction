import React from "react";
import {
  Theme,
  createMuiTheme,
  InputLabel,
  FormControl,
  MuiThemeProvider,
} from "@material-ui/core";
import MUIRichTextEditor from "mui-rte";
import { stateToHTML } from "draft-js-export-html";
import { Field, ErrorMessage, FormikProps } from "formik";

import styles from "./RichTextEditorFormControl.module.scss";

export interface IRichTextEditorProps {
  name: string;
  label: string;
  hint?: string;
  height?: string;
  formik: FormikProps<any>;
  className?: string;
  fullWidth?: boolean;
}

export class RichTextEditorFormControl extends React.Component<
  IRichTextEditorProps
  > {
  private defaultTheme: Theme;
  private richTextControls = [
    "bold",
    "italic",
    "underline",
    "numberList",
    "bulletList",
    "link",
  ];

  constructor(props: IRichTextEditorProps) {
    super(props);

    this.defaultTheme = createMuiTheme();
    Object.assign(this.defaultTheme, {
      overrides: {
        MUIRichTextEditor: {
          editor: {
            height: this.props.height || "calc(var(--spacing) * 20)",
            overflow: "scroll",
            borderBottom: "1px solid var(--c-grey-d20)"
          },
          placeHolder: {
            // make the whole editor clickable
            height: "calc(100% - 55px)" 
          },
        },
      },
    });
  }

  hasError() {
    return (
      this.props.formik.touched[this.props.name] !== undefined &&
      this.props.formik.errors[this.props.name] !== undefined
    );
  }

  render() {
    return (
      <MuiThemeProvider theme={this.defaultTheme}>
        <FormControl id={this.props.name} fullWidth={this.props.fullWidth} className={this.props.className}>
          <InputLabel
            error={this.hasError()}
            htmlFor={this.props.name}
            className={styles.label}
            shrink
          >
            {this.props.label}
          </InputLabel>
          <MUIRichTextEditor
            label={this.props.hint}
            controls={this.richTextControls}
            onChange={(state: any) => {
              const content = state.getCurrentContent();
              this.props.formik.setFieldValue(
                this.props.name,
                content.hasText() ? stateToHTML(content) : "",
                true
              );
            }}
          ></MUIRichTextEditor>
          <Field name={this.props.name} type="hidden"></Field>
          <div hidden={!this.hasError()} className={styles.error}>
            <p className="MuiFormHelperText-root Mui-error">
              <ErrorMessage name={this.props.name} />
            </p>
          </div>
        </FormControl>
      </MuiThemeProvider>
    );
  }
}
